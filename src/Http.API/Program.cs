using System.Text.Encodings.Web;
using System.Text.Unicode;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;

// config database, use postgresql as default;
var connectionString = configuration.GetConnectionString("Default");
services.AddDbContextPool<QueryDbContext>(option =>
{
    _ = option.UseNpgsql(connectionString, sql =>
    {
        _ = sql.MigrationsAssembly("Http.API");
        _ = sql.CommandTimeout(10);
    });
});
services.AddDbContextPool<CommandDbContext>(option =>
{
    _ = option.UseNpgsql(connectionString, sql =>
    {
        _ = sql.MigrationsAssembly("Http.API");
        _ = sql.CommandTimeout(10);
    });
});

// config redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = builder.Configuration.GetConnectionString("RedisInstanceName");
});
services.AddSingleton(typeof(CacheService));

// inject datastores and managers
services.AddHttpContextAccessor();
services.AddDataStore();
services.AddManager();

#region OpenTelemetry:log/trace/metric
var otlpEndpoint = configuration.GetSection("OTLP")
    .GetValue<string>("Endpoint")
    ?? "http://localhost:4317";
services.AddOpenTelemetry("poll", opt =>
{
    opt.Endpoint = new Uri(otlpEndpoint);
});

#endregion
#region 接口相关内容:jwt/authorization/cors
// config jwt
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.SaveToken = true;
    var sign = configuration.GetSection("Authentication")["Schemes:Bearer:Sign"];
    if (string.IsNullOrEmpty(sign))
    {
        throw new Exception("未找到有效的jwt配置");
    }
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sign)),
        ValidIssuer = configuration.GetSection("Authentication")["Schemes:Bearer:ValidIssuer"],
        ValidAudience = configuration.GetSection("Authentication")["Schemes:Bearer:ValidAudiences"],
        ValidateIssuer = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true
    };
});

// config authorization
services.AddAuthorization(options =>
{
    options.AddPolicy(Const.User, policy =>
        policy.RequireRole(Const.AdminUser, Const.User));
    options.AddPolicy(Const.AdminUser, policy =>
        policy.RequireRole(Const.AdminUser));
});

// config cors
services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        _ = builder.AllowAnyOrigin();
        _ = builder.AllowAnyMethod();
        _ = builder.AllowAnyHeader();
    });
});
#endregion
#region openAPI swagger
// api 接口文档设置
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    c.SwaggerDoc("admin", new OpenApiInfo
    {
        Title = "poll",
        Description = "Admin API 文档",
        Version = "v1"
    });
    c.SwaggerDoc("client", new OpenApiInfo
    {
        Title = "poll client",
        Description = "Client API 文档",
        Version = "v1"
    });
    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
    foreach (var item in xmlFiles)
    {
        try
        {
            c.IncludeXmlComments(item, includeControllerXmlComments: true);
        }
        catch (Exception) { }
    }
    c.SupportNonNullableReferenceTypes();
    c.DescribeAllParametersInCamelCase();
    c.CustomOperationIds((z) =>
    {
        var descriptor = (ControllerActionDescriptor)z.ActionDescriptor;
        return $"{descriptor.ControllerName}_{descriptor.ActionName}";
    });
    c.SchemaFilter<EnumSchemaFilter>();
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
#endregion

services.AddHealthChecks();
services.AddControllers()
    .ConfigureApiBehaviorOptions(o =>
    {
        o.InvalidModelStateResponseFactory = context =>
        {
            return new CustomBadRequest(context, null);
        };
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseCors("default");
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/client/swagger.json", name: "client");
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "admin");
    });
}
else
{
    // 生产环境需要新的配置
    _ = app.UseCors("default");
    //app.UseHsts();
    _ = app.UseHttpsRedirection();
}

app.UseStaticFiles();

// 异常统一处理
app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        context.Response.StatusCode = 500;
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        var result = new {
            Title = "异常错误",
            exception?.Source,
            Detail = exception?.Message + exception?.InnerException?.Message,
            exception?.StackTrace,
            Status = 500,
            TraceId = context.TraceIdentifier
        };
        await context.Response.WriteAsJsonAsync(result);
    });
});

app.UseHealthChecks("/health");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.MapFallbackToFile("index.html");

using (app)
{
    //app.Start();
    // 初始化工作
    await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
    {
        IServiceProvider provider = scope.ServiceProvider;
        await InitDataTask.InitDataAsync(provider);
    }
    app.Run();
}

public partial class Program { }