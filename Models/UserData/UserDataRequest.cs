using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class UserDataRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public DateOnly Birth { set; get; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { set; get; }
        public string? Phone { set; get; }

    }
}