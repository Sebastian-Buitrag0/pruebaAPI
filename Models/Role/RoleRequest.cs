using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    public class RoleRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Description { get; set;}
    }
}