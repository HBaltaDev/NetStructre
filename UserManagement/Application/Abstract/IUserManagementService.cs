using NetStructre.UserManagement.Dto.Request;

namespace NetStructre.Applications.UserManagement.Abstract;

public interface IUserManagementService : IApplicationService
{
    Task<string> SignInAsync(SignInRequest request);
}