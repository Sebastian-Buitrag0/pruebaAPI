using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Services;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using pruebaAPI.Models.Token;

namespace pruebaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(TokenGenerate tokenGenerate, IUserRespoitory userService, IAuthRepository authRepository) : ControllerBase
    {
        private readonly TokenGenerate _tokenGenerate = tokenGenerate;
        private readonly IUserRespoitory _userService = userService; 

        private readonly IAuthRepository _authRepository = authRepository;

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest loginRequest)
        {
            try
            {

                var user = _userService.ValidateUser(loginRequest.Username, loginRequest.Password);
                
                var (accessToken, refreshToken) = _tokenGenerate.GenerateTokens(user);
                _authRepository.SaveRefreshToken(refreshToken);
                return Ok(new { accessToken, refreshToken.Token });
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRequest userRequest)
        {
            var user = _userService.AddUser(userRequest);
            return CreatedAtAction(nameof(Login), new { id = user.Id }, user);
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest token)
        {   
            var refreshToken = _authRepository.GetRefreshToken(new RefreshTokenRequest { Token = token.Token });
            if (refreshToken == Guid.Empty)
                return Unauthorized(new { message = "Invalid refresh token" });
            var user = _authRepository.GetUserByRefreshToken(new RefreshTokenRequest { Token = token.Token });
            _authRepository.ValidateUniqueUser(token);
            var (newAccessToken, newRefreshToken) = _tokenGenerate.GenerateTokens(user!);
            return new ObjectResult(new { accessToken = newAccessToken, refreshToken = newRefreshToken.Token });
        }
    }
}