using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class ProductSaleRequest
    {
        public Guid? Product { get; set; }

        public int Quantity { get; set; }
    }
}