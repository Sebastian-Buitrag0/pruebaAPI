using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class CategoryResponse
    {
        public Guid Id { set; get; }
        public string? Name { set; get; }

        public string? Description { set; get; }
    }
}