using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class Product{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
}