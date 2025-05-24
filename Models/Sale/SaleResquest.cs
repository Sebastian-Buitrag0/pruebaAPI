using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    
    public class SaleRequest
    {
        [Required(ErrorMessage = "User is required")]
        public required Guid User { get; set; }
        
        [Required(ErrorMessage = "Products is required")]
        public required List<Guid> ProductsSale { get; set; } = new List<Guid>();
        
        public DateTime SaleDate { get; } = DateTime.Now;
    }
}