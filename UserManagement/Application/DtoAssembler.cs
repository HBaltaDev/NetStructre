using NetStructre.Applications.UserManagement.Abstract;
using NetStructre.UserManagement.Dto.Response;

namespace NetStructre.Applications.UserManagement;

public class DtoAssembler : IDtoAssembler
{
    public SignInResponse SignInResponse(string email)
    {
        return new SignInResponse { Email = email };
    }
}