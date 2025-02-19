using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class SaleResponse
    {
        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];

        public Guid Id { set; get; }
        public DateTime SaleDate { set; get; }
        public double Amount { set; get; }
        public int Quantity { set; get; }
    }
}