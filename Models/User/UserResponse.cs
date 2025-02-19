using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class UserResponse
    {
        public required UserData? UserData { set; get; }
        public Guid Id { set; get; }
        public string? Username { set; get; }
        public string? Password { set; get; }
    }
}