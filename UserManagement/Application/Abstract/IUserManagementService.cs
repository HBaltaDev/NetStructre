using NetStructre.Infrastructure.DtoBase.ResponseBase;
using NetStructre.UserManagement.Dto.Request;

namespace NetStructre.Applications.UserManagement.Abstract;

public interface IUserManagementService : IApplicationService
{
    Task<ResponseBase> SignInAsync(SignInRequest request);
}