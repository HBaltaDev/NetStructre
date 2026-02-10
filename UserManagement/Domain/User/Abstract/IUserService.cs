namespace NetStructre.UserManagement.Domain.Abstract;

public interface IUserService
{
    Task<string> SignIn(string email, string password);
    Task SignOut();
}