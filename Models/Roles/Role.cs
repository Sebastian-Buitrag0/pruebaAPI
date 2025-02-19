using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class Role 
    {
        public Guid Id = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set;}
    }
}