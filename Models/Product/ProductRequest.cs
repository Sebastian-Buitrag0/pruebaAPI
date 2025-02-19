namespace pruebaAPI.Models
{
    public class ProductRequest
    {
        public Guid CategoryId { set; get; }
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

    }
}