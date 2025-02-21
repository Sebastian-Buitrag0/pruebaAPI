using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace pruebaAPI.Services
{
    public class TokenGenerate
    {
        private readonly IConfiguration _configuration;

        public TokenGenerate(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Models.UserResponse user)
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
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        public (string AccessToken, string RefreshToken) GenerateTokens(Models.UserResponse user)
        {
            var accessToken = GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            return (accessToken, refreshToken);
        }
    }
}