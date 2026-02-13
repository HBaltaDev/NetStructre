using Infrastructure.DtoBase.ResponseBase;
using Server.UserManagement.Dto.Request;
using Server;

namespace Server.Applications.UserManagement.Abstract;

public interface IUserManagementService : IApplicationService
{
    Task<ResponseBase> SignInAsync(SignInRequest request);
}