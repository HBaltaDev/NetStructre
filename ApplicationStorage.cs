using Microsoft.Extensions.DependencyInjection;
using NetStructre.UserManagement.DI;

namespace NetStructre;

public static class ApplicationStorage
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddUserManagement();

        return services;
    }
}