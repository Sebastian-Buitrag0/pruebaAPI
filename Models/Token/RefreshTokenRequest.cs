using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models.Token
{
    public class RefreshTokenRequest
    {
        [Required(ErrorMessage = "Token is required")]
        public string? Token { get; set; }
    }
}