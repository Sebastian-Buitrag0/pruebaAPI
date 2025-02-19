using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class SaleRequest
    {

        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];

        
        public DateTime SaleDate { set; get; }
        public double Amount => Products?.Sum(p => p.Price) ?? 0;
        public int Quantity => Products?.Count ?? 0;

    }
}