using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{

    [PrimaryKey(nameof(Id))]
    public class ProductResponse{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
}