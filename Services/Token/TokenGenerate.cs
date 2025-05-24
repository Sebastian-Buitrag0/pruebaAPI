using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using pruebaAPI.Models;

namespace pruebaAPI.Services
{
    public class TokenGenerate(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secretKey = _configuration.GetValue<string>("JWT:Key");
            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("La clave JWT no está configurada.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(User user)
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Created = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddDays(7),
                    UserId = user.Id,
                    User = user,
                    Revoked = null
                };
            }
        }


        public (string AccessToken, RefreshToken RefreshToken) GenerateTokens(User user)
        {   
            
            var accessToken = GenerateToken(user);
            var refreshToken = GenerateRefreshToken(user);
            return (accessToken, refreshToken);
        }
    }
}