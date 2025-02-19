using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class SaleRequest
    {

        public required Guid User { set; get; }
        public required List<Guid> Products { set; get; } = [];
        public DateTime SaleDate { set; get; }

    }
}