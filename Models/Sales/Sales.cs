using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class Sales
    {
        public Guid Id = Guid.NewGuid();
        public DateTime SaleDate { set; get; }
        public double Amount { set; get; }
        public int Quantity { set; get; }

        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];
    }
}