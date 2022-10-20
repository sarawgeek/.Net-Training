using JWTDemo.Models;

namespace JWTDemo.Repos
{
    public interface IUserRepo
    {
        List<User> AllUsers();

        int CreateUser(Register user);

        User LoginUser(Login login);

        string GenerateToken(User user);

    }
}
