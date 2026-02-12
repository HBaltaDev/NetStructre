using NetStructre.Applications.UserManagement;
using NetStructre.Applications.UserManagement.Abstract;
using NetStructre.UserManagement.Domain.Abstract;
using NetStructre.UserManagement.Domain.User;

namespace NetStructre.UserManagement.DI;

public static class DIService
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services)
    {

        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<IDtoAssembler, DtoAssembler>();
        
        services.AddScoped<IUserService, UserService>();
        
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