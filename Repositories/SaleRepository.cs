using pruebaAPI.Data;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class SaleRepository(ApplicationDbContext context) : ISaleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public SaleResponse AddSale(SaleRequest request)
        {
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleDate = request.SaleDate,
                Amount = request.Amount,
                Quantity = request.Quantity,
                User = request.User,
                Products = request.Products
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
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id)
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
            return _context.Sales.Select(sale => new SaleResponse
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
                sale.SaleDate = request.SaleDate;
                sale.Amount = request.Amount;
                sale.Quantity = request.Quantity;
                sale.User = request.User;
                sale.Products = request.Products;

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