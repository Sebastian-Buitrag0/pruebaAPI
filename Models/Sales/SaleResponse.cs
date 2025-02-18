using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class SaleResponse
    {
        public Guid Id { set; get; }
        public DateTime SaleDate { set; get; }
        public double Amount { set; get; }
        public int Quantity { set; get; }


        public User? User { set; get; }
        public List<Product>? Products { set; get; } = [];
    }
}