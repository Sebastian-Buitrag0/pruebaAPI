using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class SalesRequest
    {
        public DateTime SaleDate { set; get; }
        public double Amount { set; get; }
        public int Quantity { set; get; }


        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];
    }
}