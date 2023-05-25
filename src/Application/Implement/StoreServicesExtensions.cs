namespace Application.Implement;

public static partial class StoreServicesExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddScoped(typeof(DataStoreContext));
        services.AddScoped(typeof(PollCategoryQueryStore));
        services.AddScoped(typeof(PollIssueQueryStore));
        services.AddScoped(typeof(PollOptionQueryStore));
        services.AddScoped(typeof(PollTagQueryStore));
        services.AddScoped(typeof(RolePermissionQueryStore));
        services.AddScoped(typeof(SystemConfigQueryStore));
        services.AddScoped(typeof(SystemLogsQueryStore));
        services.AddScoped(typeof(SystemMenuQueryStore));
        services.AddScoped(typeof(SystemOrganizationQueryStore));
        services.AddScoped(typeof(SystemPermissionQueryStore));
        services.AddScoped(typeof(SystemRoleQueryStore));
        services.AddScoped(typeof(SystemUserQueryStore));
        services.AddScoped(typeof(UserQueryStore));
        services.AddScoped(typeof(PollCategoryCommandStore));
        services.AddScoped(typeof(PollIssueCommandStore));
        services.AddScoped(typeof(PollOptionCommandStore));
        services.AddScoped(typeof(PollTagCommandStore));
        services.AddScoped(typeof(RolePermissionCommandStore));
        services.AddScoped(typeof(SystemConfigCommandStore));
        services.AddScoped(typeof(SystemLogsCommandStore));
        services.AddScoped(typeof(SystemMenuCommandStore));
        services.AddScoped(typeof(SystemOrganizationCommandStore));
        services.AddScoped(typeof(SystemPermissionCommandStore));
        services.AddScoped(typeof(SystemRoleCommandStore));
        services.AddScoped(typeof(SystemUserCommandStore));
        services.AddScoped(typeof(UserCommandStore));

    }

    public static void AddManager(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped<IPollCategoryManager, PollCategoryManager>();
        services.AddScoped<IPollIssueManager, PollIssueManager>();
        services.AddScoped<IPollOptionManager, PollOptionManager>();
        services.AddScoped<IPollTagManager, PollTagManager>();
        services.AddScoped<IRolePermissionManager, RolePermissionManager>();
        services.AddScoped<ISystemConfigManager, SystemConfigManager>();
        services.AddScoped<ISystemLogsManager, SystemLogsManager>();
        services.AddScoped<ISystemMenuManager, SystemMenuManager>();
        services.AddScoped<ISystemOrganizationManager, SystemOrganizationManager>();
        services.AddScoped<ISystemPermissionManager, SystemPermissionManager>();
        services.AddScoped<ISystemRoleManager, SystemRoleManager>();
        services.AddScoped<ISystemUserManager, SystemUserManager>();
        services.AddScoped<IUserManager, UserManager>();

    }
}
