using Server.UserManagement.DI;

namespace Server;

public static class ApplicationStorage
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddUserManagement();

        return services;
    }
}