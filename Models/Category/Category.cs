using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class Category
    {
        public Guid Id = Guid.NewGuid();
        public string? Name { set; get; }

        public string? Description { set; get; }
    }
}