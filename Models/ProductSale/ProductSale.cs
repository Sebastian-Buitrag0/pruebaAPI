using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class ProductSale
    {
        public Guid Id = Guid.NewGuid();
        public required Product? Product { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }

    }
}