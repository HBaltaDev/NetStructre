using Infrastructure.DbContext;
using Server.Infrastructure.ExectionHandling.Localization;
using Server.UserManagement.DI;

namespace Server;

public static class ApplicationStorage
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IErrorLocalizer, ErrorLocalizer>();
        services.AddScoped<IDbContext, DbContext>();
        
        services.AddUserManagement();
        
        return services;
    }
}