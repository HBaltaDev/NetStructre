using Server.UserManagement.Domain.Abstract;

namespace Server.UserManagement.Domain.User;

public class UserService : IUserService
{
    public async Task<string> SignIn(string email, string password)
    {
        if (email == "hbalta" && password == "12345")
        {
            return "success";
        }
        
        return"fail";
    }

    public Task SignOut()
    {
        throw new NotImplementedException();
    }
}