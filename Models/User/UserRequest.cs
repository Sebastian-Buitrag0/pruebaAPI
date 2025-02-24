using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    public class UserRequest
    {
        [Required(ErrorMessage = "UserData is required")]
        public required UserData? UserData { set; get; }

        [Required(ErrorMessage = "Role is required")]
        public required Guid Role { set; get; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { set; get; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? Password { set; get; }
    }
}