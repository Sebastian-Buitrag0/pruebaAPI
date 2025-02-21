using pruebaAPI.Models;
using pruebaAPI.Models.Token;

namespace pruebaAPI.Interfaces
{
    public interface IAuthRepository
    {
        bool Register(User user);
        bool Login(string username, string password);
        User? UserExists(string username);
        string SaveRefreshToken(RefreshToken token);
        User? GetUserByRefreshToken(RefreshTokenRequest token);
        Guid GetRefreshToken(RefreshTokenRequest token);

        void ValidateUniqueUser(RefreshTokenRequest username);

    }
}