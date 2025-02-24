using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { set; get; }

        public string? Description { set; get; }
    }
}