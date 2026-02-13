using Infrastructure.DtoBase.ResponseBase;

namespace Server.UserManagement.Dto.Response;

public record SignInResponse : ResponseBase
{
    public string Email { get; init; }
}