using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class ProductSaleRequest
    {
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public double Amount => Product != null ? Product.Price : 0;
    }
}