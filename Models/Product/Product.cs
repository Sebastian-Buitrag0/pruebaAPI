using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class Product
    {
        public required Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public  Category? Category { set; get; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}