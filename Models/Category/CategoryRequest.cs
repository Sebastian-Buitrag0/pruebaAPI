using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class CategoryRequest
    {
        public string? Name { set; get; }

        public string? Description { set; get; }
    }
}