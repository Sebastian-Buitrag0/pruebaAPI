using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Models;
namespace pruebaAPI.Repositories
{
    public class ProductoRepository(ApplicationDbContext context) : IProductoRepository
    {

        private readonly ApplicationDbContext _context = context;

       
        public void AddProduct(ProductRequest request)
        {

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var index = _context.Products.Find(id)!;
            if (index != null)
                _context.Products.Remove(index);
            _context.SaveChanges();

        }

        public ProductResponse GetProduct(Guid id)
        {
            var product = _context.Products.Include(product => product.Category).FirstOrDefault(product => product.Id == id);
            if (product == null)
                return null;

            return new ProductResponse
            {
                Id = product!.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category
            };
        }

        public IEnumerable<ProductResponse> GetProducts() =>
            _context.Products
            .Include(product => product.Category)
            .Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category
            });


        public void UpdateProduct(Guid id, ProductRequest request)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId; 
                _context.Products.Update(product);
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
    }
}