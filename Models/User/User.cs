using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class User
    {
        public Guid Id = Guid.NewGuid();
        public string? Username { set; get; }
        public string? Password { set; get; }
    }
}