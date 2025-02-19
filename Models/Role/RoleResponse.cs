using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class RoleResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set;}
    }
}