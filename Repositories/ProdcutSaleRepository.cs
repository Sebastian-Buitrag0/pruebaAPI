using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class ProductSaleRepository(ApplicationDbContext context) : IProductSale
    {
        
        private readonly ApplicationDbContext _context = context;

        public ProductSaleResponse AddProductSale(ProductSaleRequest request)
        {
          if (request.Product == null)
              throw new ArgumentNullException(nameof(request.Product));
              
          var product = _context.Products.FirstOrDefault(r => r.Id == request.Product) ?? throw new ArgumentException("Product not found");
            var productSale = new ProductSale
            {
                Product = product,
                Quantity = request.Quantity,
                PriceAtSale = product.Price,
            };

           _context.Add(productSale);
            _context.SaveChanges();

            return new ProductSaleResponse
            {
                Id = productSale.Id,
                Product = product,
                Quantity = productSale.Quantity,
                PriceAtSale = product.Price,
            };
        }

        public void DeleteProductSale(Guid id)
        {
            var productSale = _context.ProductSales.Find(id);
            if (productSale != null)
            {
                _context.ProductSales.Remove(productSale);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("ProductSale not found");
            }
        }

        public ProductSaleResponse GetProductSale(Guid id)
        {
            var productSale = _context.ProductSales
                .Include(ps => ps.Product)
                .FirstOrDefault(ps => ps.Id == id) ?? throw new KeyNotFoundException("ProductSale not found");
            return new ProductSaleResponse
            {
                Id = productSale.Id,
                Product = productSale.Product,
                Quantity = productSale.Quantity,
                PriceAtSale = productSale.PriceAtSale,
            };
        }

        public IEnumerable<ProductSaleResponse> GetProductSales()
        {
            return _context.ProductSales
                .Include(ps => ps.Product)
                .ThenInclude(p => p!.Category)
                .Select(productSale => new ProductSaleResponse
                {
                    Id = productSale.Id,
                    Product = productSale.Product,
                    Quantity = productSale.Quantity,
                    PriceAtSale = productSale.PriceAtSale,
                });
        }

        public void UpdateProductSale(Guid id, ProductSaleRequest updatedProductSale)
        {
            var productSale = _context.ProductSales.Find(id);
            if (productSale != null)
            {
                if (productSale.Product == null)
                    throw new InvalidOperationException("Product is missing for this sale.");
                productSale.Quantity = updatedProductSale.Quantity;
                _context.ProductSales.Update(productSale);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("ProductSale not found");
            }
        }
    }
}