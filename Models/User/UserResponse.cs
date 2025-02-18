using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class UserResponse
    {
        public Guid Id { set; get; }
        public string? Username { set; get; }
        public string? Password { set; get; }
    }
}