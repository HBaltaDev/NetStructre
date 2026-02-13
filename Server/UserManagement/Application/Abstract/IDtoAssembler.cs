using Server.UserManagement.Dto.Request;
using Server.UserManagement.Dto.Response;

namespace Server.Applications.UserManagement.Abstract;

public interface IDtoAssembler
{
    public SignInResponse SignInResponse(string email);
}