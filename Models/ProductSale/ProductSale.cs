using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class ProductSale
    {
        public Guid Id = Guid.NewGuid();
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtSale { get; set; }

    }
}