using Infrastructure.DtoBase.RequestBase;

namespace Server.UserManagement.Dto.Request;

public record SignInRequest : RequestBase
{
    public string Email { get; init; }
    public string Password { get; init; }
}