using NetStructre.Infrastructure.DtoBase.ResponseBase;

namespace NetStructre.UserManagement.Dto.Response;

public record SignInResponse : ResponseBase
{
    public string Email { get; init; }
}