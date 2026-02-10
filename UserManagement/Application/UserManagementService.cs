using NetStructre.Applications.UserManagement.Abstract;
using NetStructre.UserManagement.Domain.Abstract;
using NetStructre.UserManagement.Dto.Request;

namespace NetStructre.Applications.UserManagement;

public class UserManagementService(IUserService userService) : IUserManagementService
{
    public async Task<string> SignInAsync(SignInRequest request)
    {
        return await userService.SignIn(request.Email, request.Password);
    }
}