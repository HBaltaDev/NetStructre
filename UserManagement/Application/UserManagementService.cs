using NetStructre.Applications.UserManagement.Abstract;
using NetStructre.Infrastructure.DtoBase.ResponseBase;
using NetStructre.UserManagement.Domain.Abstract;
using NetStructre.UserManagement.Dto.Request;

namespace NetStructre.Applications.UserManagement;

public class UserManagementService(IUserService userService, IDtoAssembler dtoAssembler) : IUserManagementService
{
    public async Task<ResponseBase> SignInAsync(SignInRequest request)
    {
        //throw new ServiceException(StatusCodes.ALREADY_EXISTS, "Test");

        var result = await userService.SignIn(request.Email, request.Password);
        
        return dtoAssembler.SignInResponse(result);
    }
}