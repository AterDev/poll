﻿using Application;
using Microsoft.AspNetCore.Http;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Application;

/// <summary>
/// 服务注册扩展
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// 添加opentelemetry 服务及选项
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceName"></param>
    /// <param name="otlpOptions"></param>
    /// <param name="loggerOptions"></param>
    /// <param name="tracerProvider"></param>
    /// <param name="meterProvider"></param>
    public static IServiceCollection AddOpenTelemetry(this IServiceCollection services,
        string serviceName,
        Action<OtlpExporterOptions>? otlpOptions = null,
        Action<OpenTelemetryLoggerOptions>? loggerOptions = null,
        Action<TracerProviderBuilder>? tracerProvider = null,
        Action<MeterProviderBuilder>? meterProvider = null)
    {
        ResourceBuilder resource = ResourceBuilder.CreateDefault()
            .AddService(serviceName: serviceName, serviceInstanceId: Environment.MachineName);

        otlpOptions ??= new Action<OtlpExporterOptions>(opt =>
        {
            opt.Endpoint = new Uri("http://localhost:4317");
        });

        loggerOptions ??= new Action<OpenTelemetryLoggerOptions>(options =>
        {
            options.SetResourceBuilder(resource);
            options.AddOtlpExporter(otlpOptions);
            options.ParseStateValues = true;
            options.IncludeFormattedMessage = true;
            options.IncludeScopes = true;
        });
        // 返回内容最大长度截取
        int maxLength = 2048;
        tracerProvider ??= new Action<TracerProviderBuilder>(options =>
        {
            options.AddSource(serviceName)
                .SetResourceBuilder(resource)
                .AddHttpClientInstrumentation(options =>
                {
                    options.RecordException = true;
                    options.EnrichWithHttpRequestMessage = (activity, httpRequestMessage) =>
                    {
                        if (httpRequestMessage.Content != null)
                        {
                            System.Net.Http.Headers.HttpContentHeaders headers = httpRequestMessage.Content.Headers;
                            // 过滤过长或文件类型
                            long contentLength = headers.ContentLength ?? 0;
                            string? contentType = headers.ContentType?.ToString();
                            if (contentLength > maxLength * 2
                            || (contentType != null && contentType.Contains("multipart/form-data"))) { }
                            else
                            {
                                string body = httpRequestMessage.Content.ReadAsStringAsync().Result;
                                activity.SetTag("requestBody", body);
                            }
                        }
                    };

                    options.EnrichWithHttpResponseMessage = (activity, httpResponseMessage) =>
                    {
                        // TODO:添加自定义过滤
                        if (httpResponseMessage.Content != null)
                        {
                            if (httpResponseMessage.Content.Headers?.ContentLength < maxLength)
                            {
                                // 不要使用await:The stream was already consumed. It cannot be read again
                                string body = httpResponseMessage.Content.ReadAsStringAsync().Result;
                                body = body.Length > maxLength ? body[0..maxLength] : body;
                                activity.SetTag("responseBody", body);
                            }
                        }
                    };
                    options.EnrichWithException = (activity, exception) =>
                    {
                    };
                })
                .AddAspNetCoreInstrumentation(options =>
                {
                    options.RecordException = true;
                    options.EnrichWithHttpRequest = async (activity, request) =>
                    {
                        IHeaderDictionary headers = request.Headers;
                        // 过滤过长或文件类型
                        long contentLength = request.ContentLength ?? 0;
                        string? contentType = request.ContentType?.ToString();
                        if (contentLength > maxLength * 2
                        || (contentType != null && contentType.Contains("multipart/form-data")))
                        {
                            activity.SetTag("requestBody", "file upload");
                        }
                        else
                        {
                            request.EnableBuffering();
                            request.Body.Position = 0;
                            StreamReader reader = new(request.Body);
                            activity.SetTag("requestBody", await reader.ReadToEndAsync());
                            request.Body.Position = 0;
                        }
                    };

                    options.EnrichWithHttpResponse = (activity, response) =>
                    {
                    };

                    options.EnrichWithException = (activity, exception) =>
                    {
                        activity.SetTag("stackTrace", exception.StackTrace);
                        activity.SetTag("message", exception.Message);
                    };
                })
                .AddSqlClientInstrumentation()
                .AddOtlpExporter(otlpOptions);
        });

        meterProvider = new Action<MeterProviderBuilder>(options =>
        {
            options.AddMeter(serviceName)
                .SetResourceBuilder(resource)
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(otlpOptions);
        });

        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddOpenTelemetry(loggerOptions);
        });
        services.AddOpenTelemetry()
            .WithTracing(tracerProvider)
            .WithMetrics(meterProvider);

        return services;
    }
}
