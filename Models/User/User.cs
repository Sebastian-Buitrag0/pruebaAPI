using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class User
    {
        public required UserData? UserData { set; get; }
        public required Role? Role { set; get; }
        public Guid Id = Guid.NewGuid();
        public string? Username { set; get; }
        public string? Password { set; get; }
    }
}