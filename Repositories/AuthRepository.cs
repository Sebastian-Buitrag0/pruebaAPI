using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;
using pruebaAPI.Models.Token;

namespace pruebaAPI.Repositories
{
    public class AuthRepository(ApplicationDbContext context) : IAuthRepository
    {

        private readonly ApplicationDbContext _context = context;

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public bool Register(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;

        }

        public string SaveRefreshToken(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            _context.SaveChanges();
            return token.Token;
        }

        public User? UserExists(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
            
        }

        public Guid GetRefreshToken(RefreshTokenRequest token)
        {
            var refreshToken = _context.RefreshTokens.FirstOrDefault(t => t.Token == token.Token);
            return refreshToken != null ? refreshToken.Id : Guid.Empty;
        }

        public User? GetUserByRefreshToken(RefreshTokenRequest token)
        {
            var refreshToken = _context.RefreshTokens.FirstOrDefault(t => t.Token == token.Token);
            return refreshToken != null ? _context.Users.FirstOrDefault(u => u.Id == refreshToken.UserId) : null;
        }

        public void ValidateUniqueUser(RefreshTokenRequest token)
        {
            var currentToken = _context.RefreshTokens.FirstOrDefault(t => t.Token == token.Token);
            if (currentToken != null)
            {
                var userTokens = _context.RefreshTokens
                    .Where(t => t.UserId == currentToken.UserId)
                    .OrderByDescending(t => t.Created)
                    .ToList();

                
                if (userTokens.Count > 1)
                {
                    var tokensToRemove = userTokens.Skip(1);
                    _context.RefreshTokens.RemoveRange(tokensToRemove);
                    _context.SaveChanges();
                }
            }
        }
    }
}