using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class CashMovementsRepository(ApplicationDbContext context) : ICashMovementsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public CashMovementsResponse AddCashMovements(CashMovementsRequest request)
        {
            var cashMovements = new CashMovements
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                Amount = request.Amount,
                Type = request.Type,
                SaleId = request.SaleId
            };
            _context.CashMovements.Add(cashMovements);
            _context.SaveChanges();
            
            return new CashMovementsResponse
            {
                Id = cashMovements.Id,
                Date = cashMovements.Date,
                Amount = cashMovements.Amount,
                Type = cashMovements.Type,
                SaleId = cashMovements.SaleId
            };
        }

        public void DeleteCashMovements(Guid id)
        {
            var cashMovements = _context.CashMovements.Find(id);
            if (cashMovements != null)
            {
                _context.CashMovements.Remove(cashMovements);
                _context.SaveChanges();
            }
        }

        public CashMovementsResponse GetCashMovements(Guid id)
        {
            var cashMovements = _context.CashMovements
                .FirstOrDefault(c => c.Id == id) ?? 
                    throw new KeyNotFoundException("CashMovements not found");
            return new CashMovementsResponse
            {
                Id = cashMovements.Id,
                Date = cashMovements.Date,
                Amount = cashMovements.Amount,
                Type = cashMovements.Type,
                SaleId = cashMovements.SaleId
            };
        }

        public IEnumerable<CashMovementsResponse> GetCashMovements() =>
            _context.CashMovements.Select(cashMovements => new CashMovementsResponse
            {
                Id = cashMovements.Id,
                Date = cashMovements.Date,
                Amount = cashMovements.Amount,
                Type = cashMovements.Type,
                SaleId = cashMovements.SaleId
            });

        public void UpdateCashMovements(Guid id, CashMovementsRequest request)
        {
            var cashMovements = _context.CashMovements.Find(id);
            if (cashMovements != null)
            {
                cashMovements.Date = request.Date;
                cashMovements.Amount = request.Amount;
                cashMovements.Type = request.Type;
                cashMovements.SaleId = request.SaleId;
                _context.CashMovements.Update(cashMovements);
                _context.SaveChanges();
            }
        }
    }
}