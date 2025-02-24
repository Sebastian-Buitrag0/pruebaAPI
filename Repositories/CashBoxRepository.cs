using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class CashBoxRepository(ApplicationDbContext context) : ICashBoxRepository
    {
        private readonly ApplicationDbContext _context = context;

        public CashBoxResponse AddCashBox(CashBoxRequest request)
        {
            var cashBox = new CashBox
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                Amount = request.Amount,
                Type = request.Type,
                SaleId = request.SaleId
            };
            _context.CashBoxes.Add(cashBox);
            _context.SaveChanges();
            
            return new CashBoxResponse
            {
                Id = cashBox.Id,
                Date = cashBox.Date,
                Amount = cashBox.Amount,
                Type = cashBox.Type,
                SaleId = cashBox.SaleId
            };
        }

        public void DeleteCashBox(Guid id)
        {
            var cashBox = _context.CashBoxes.Find(id);
            if (cashBox != null)
            {
                _context.CashBoxes.Remove(cashBox);
                _context.SaveChanges();
            }
        }

        public CashBoxResponse GetCashBox(Guid id)
        {
            var cashBox = _context.CashBoxes
                .FirstOrDefault(c => c.Id == id) ?? 
                    throw new KeyNotFoundException("CashBox not found");
            return new CashBoxResponse
            {
                Id = cashBox.Id,
                Date = cashBox.Date,
                Amount = cashBox.Amount,
                Type = cashBox.Type,
                SaleId = cashBox.SaleId
            };
        }

        public IEnumerable<CashBoxResponse> GetCashBoxes() =>
            _context.CashBoxes.Select(cashBox => new CashBoxResponse
            {
                Id = cashBox.Id,
                Date = cashBox.Date,
                Amount = cashBox.Amount,
                Type = cashBox.Type,
                SaleId = cashBox.SaleId
            });

        public void UpdateCashBox(Guid id, CashBoxRequest request)
        {
            var cashBox = _context.CashBoxes.Find(id);
            if (cashBox != null)
            {
                cashBox.Date = request.Date;
                cashBox.Amount = request.Amount;
                cashBox.Type = request.Type;
                cashBox.SaleId = request.SaleId;
                _context.CashBoxes.Update(cashBox);
                _context.SaveChanges();
            }
        }
    }
}