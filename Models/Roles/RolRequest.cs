using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class RolRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set;}
    }
}