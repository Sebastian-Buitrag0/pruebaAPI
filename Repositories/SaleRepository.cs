using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class SaleRepository(ApplicationDbContext context) : ISaleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public SaleResponse AddSale(SaleRequest request)
        {
            var user = _context.Users.Find(request.User) ?? throw new KeyNotFoundException("User not found");
            var products = new List<ProductSale>();
            foreach (var productId in request.ProductsSale)
            {
            var product = _context.Products.Find(productId) ?? throw new KeyNotFoundException($"Product not found: {productId}");
            products.Add(new ProductSale { Product = product });
            }
            var sale = new Sale
            {
            Id = Guid.NewGuid(),
            SaleDate = DateTime.UtcNow,
            User = user,
            Products = products,
            Amount = products.Sum(ps => ps.Product!.Price),
            Quantity = products.Count,
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return new SaleResponse
            {
            Id = sale.Id,
            SaleDate = sale.SaleDate,
            Amount = sale.Amount,
            Quantity = sale.Quantity,
            User = sale.User,
            Products = sale.Products
            };
        }

        public void Delete(Guid id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }
        public SaleResponse GetSale(Guid id)
        {
            var sale = _context.Sales
                .Include(s => s.User)
                .Include(s => s.Products)
                    .ThenInclude(ps => ps.Product)
                        .ThenInclude(p => p!.Category)
                .FirstOrDefault(s => s.Id == id)
                ?? throw new KeyNotFoundException("Sale not found");
            return new SaleResponse
            {
                Id = sale.Id,
                SaleDate = sale.SaleDate,
                Amount = sale.Amount,
                Quantity = sale.Quantity,
                User = sale.User,
                Products = sale.Products
            };
        }

        public IEnumerable<SaleResponse> GetSales()
        {
            var sales = _context.Sales
            .Include(s => s.User!.UserData)
                .Include(s => s.User)
                    .ThenInclude(u => u!.Role)
                .Include(s => s.Products)
                    .ThenInclude(ps => ps.Product)
                        .ThenInclude(p => p!.Category)
                .ToList();

            return sales.Select(sale => new SaleResponse
            {
                Id = sale.Id,
                SaleDate = sale.SaleDate,
                Amount = sale.Amount,
                Quantity = sale.Quantity,
                User = sale.User,
                Products = sale.Products
            });
        }

        public void UpdateSale(Guid id, SaleRequest request)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {

                var user = _context.Users.Find(request.User) ?? throw new KeyNotFoundException("User not found");
                sale.SaleDate = request.SaleDate;
                sale.User = user;
                var products = new List<Product>();
                foreach (var productId in request.ProductsSale)
                {
                    var product = _context.Products.Find(productId);
                    if (product == null)
                        throw new KeyNotFoundException($"Product not found: {productId}");
                    products.Add(product);
                }
                sale.Products = products.Select(p => new ProductSale { Product = p }).ToList();
                sale.Amount = products.Sum(product => product.Price);
                sale.Quantity = products.Count;

                _context.Sales.Update(sale);
                _context.SaveChanges();
            }
        }

        public void DeleteSale(Guid id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Sale not found");
            }
        }
    }
}