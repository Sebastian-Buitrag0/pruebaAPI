using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class DataUserResponse
    {
        public Guid Id { set; get; }
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public DateOnly Birth { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }

    }
}