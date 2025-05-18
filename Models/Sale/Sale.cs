using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class Sale
    {
        public User? User { get; set; }
        public List<ProductSale> Products { get; set; } = [];

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime SaleDate { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}