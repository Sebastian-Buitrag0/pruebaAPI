using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    public class DataUserRequest
    {
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public DateOnly Birth { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }

    }
}