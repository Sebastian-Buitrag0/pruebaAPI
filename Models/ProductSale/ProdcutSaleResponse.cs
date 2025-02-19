using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class ProductSaleResponse
    {
        public Guid Id { get; set; }
        public Product? Product { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }

    }
}