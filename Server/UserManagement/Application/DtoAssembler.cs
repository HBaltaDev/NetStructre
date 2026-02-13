using Server.Applications.UserManagement.Abstract;
using Server.UserManagement.Dto.Response;

namespace Server.Applications.UserManagement;

public class DtoAssembler : IDtoAssembler
{
    public SignInResponse SignInResponse(string email)
    {
        return new SignInResponse { Email = email };
    }
}