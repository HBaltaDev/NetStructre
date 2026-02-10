using Microsoft.Extensions.DependencyInjection;
using NetStructre.UserManagement.DI;

namespace NetStructre;

public static class ApplicationStorage
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddUserManagement();
        // Infrastructure
        // services.AddScoped<IDbContext, DbContext>();
        //
        // // Repos
        // services.AddScoped<IAuditLogRepository, AuditLogRepository>();
        // services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
        // services.AddScoped<IInfoLogRepository, InfoLogRepository>();
        // services.AddScoped<ITraceLogRepository, TraceLogRepository>();
        // services.AddScoped<IWarningLogRepository, WarningLogRepository>();
        //
        // // Domain/Application
        // services.AddScoped<IAuditLogService, AuditLogService>();
        // services.AddScoped<IErrorLogService, ErrorLogService>();
        // services.AddScoped<IInfoLogService, InfoLogService>();
        // services.AddScoped<ITraceLogService, TraceLogService>();
        // services.AddScoped<IWarningLogService, WarningLogService>();
        //
        // services.AddScoped<IApplicationStorage, ApplicationStorage>();
        // services.AddScoped<IAppRunner, AppRunner>();

        return services;
    }
}