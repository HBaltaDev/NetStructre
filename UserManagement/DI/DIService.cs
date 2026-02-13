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

        return services;
    }
}