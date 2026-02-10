namespace NetStructre.UserManagement.Dto.Request;

public record SignInRequest(string Email, string Password)
{
    public string Email { get; } = Email;

    public string Password { get; } = Password;
}