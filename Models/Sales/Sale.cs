using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class Sale
    {

        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];
        
        public Guid Id = Guid.NewGuid();
        public DateTime SaleDate { set; get; }
        public double Amount { set; get; }
        public int Quantity { set; get; }

    }
}