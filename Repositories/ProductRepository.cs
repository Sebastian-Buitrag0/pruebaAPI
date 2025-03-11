using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;
namespace pruebaAPI.Repositories
{
    public class ProductoRepository(ApplicationDbContext context) : IProductoRepository
    {

        private readonly ApplicationDbContext _context = context;


        public ProductResponse AddProduct(ProductRequest request)
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
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId
            };
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
            var product = _context.Products
            .Include(product => product.Category)
            .FirstOrDefault(product => product.Id == id) 
                ?? throw new KeyNotFoundException("Product not found");
            return new ProductResponse
            {
                Id = product!.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId
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
                Category = product.Category,
                CategoryId = product.CategoryId
            });


        public void UpdateProduct(Guid id, ProductRequest request)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            
            if (product != null)
            {
                var categoryExists = _context.Categories.Any(c => c.Id == request.CategoryId);
                if (!categoryExists)
                {
                    throw new KeyNotFoundException("La categoría especificada no existe");
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }
    }
}