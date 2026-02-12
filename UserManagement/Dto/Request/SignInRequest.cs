using NetStructre.Infrastructure.Dto.RequestBase;

namespace NetStructre.UserManagement.Dto.Request;

public record SignInRequest : RequestBase
{
    public string Email { get; init; }
    public string Password { get; init; }
}
