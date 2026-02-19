using Infrastructure.DtoBase.ResponseBase;
using Infrastructure.ExceptionHandling;
using Server.Applications.UserManagement.Abstract;
using Server.Infrastructure.ExectionHandling.ErrorMessage;
using Server.Infrastructure.ExectionHandling.Localization;
using Server.UserManagement.Domain.Abstract;
using Server.UserManagement.Dto.Request;

namespace Server.UserManagement.Application;

public class UserManagementService(IUserService userService, IDtoAssembler dtoAssembler) : IUserManagementService
{
    public async Task<ResponseBase> SignInAsync(SignInRequest request)
    {
        //throw new ServiceException(StatusCodes.ALREADY_EXISTS, "Test");
        //throw new ServiceException(ErrorDefinitions.UserNotFound);
        
        var result = await userService.SignIn(request.Email, request.Password);
        
        return dtoAssembler.SignInResponse(result);
    }
}