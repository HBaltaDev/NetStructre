using Server.Applications.UserManagement;
using Server.Applications.UserManagement.Abstract;
using Server.UserManagement.Domain.Abstract;
using Server.UserManagement.Domain.User;
using Server.UserManagement.Application;

namespace Server.UserManagement.DI;

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