using System;
using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "CategoryId is required")]
        public Guid CategoryId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}