using NetStructre.UserManagement.Dto.Request;
using NetStructre.UserManagement.Dto.Response;

namespace NetStructre.Applications.UserManagement.Abstract;

public interface IDtoAssembler
{
    public SignInResponse SignInResponse(string email);
}