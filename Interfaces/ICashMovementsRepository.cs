using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{
    public interface ICashMovementsRepository
    {
        IEnumerable<CashMovementsResponse> GetCashMovements();
        CashMovementsResponse GetCashMovements(Guid id);
        CashMovementsResponse AddCashMovements(CashMovementsRequest request);
        void UpdateCashMovements(Guid id, CashMovementsRequest request);
        void DeleteCashMovements(Guid id);
    }
}