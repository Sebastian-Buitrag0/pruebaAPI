using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class DataUser
    {
        public Guid Id = Guid.NewGuid();
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public DateOnly Birth { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }

    }
}