using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Services;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;

namespace pruebaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(TokenGenerate tokenGenerate, IUserRespoitory userService) : ControllerBase
    {
        private readonly TokenGenerate _tokenGenerate = tokenGenerate;
        private readonly IUserRespoitory _userService = userService; // Servicio para manejar usuarios

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest loginRequest)
        {
            try
            {

                var user = _userService.ValidateUser(loginRequest.Username, loginRequest.Password);
                
                var (accessToken, refreshToken) = _tokenGenerate.GenerateTokens(user);
                return Ok(new { accessToken, refreshToken });
            }
            catch (KeyNotFoundException ex)
            {
                // Se devuelve un 401 si el usuario no es encontrado
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}