using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class RoleRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set;}
    }
}