using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class ProductResponse
    {
        public Category? Category { set; get; }
        public Guid CategoryId { set; get; }
        
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

    }
}