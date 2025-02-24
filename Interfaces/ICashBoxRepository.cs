using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{
    public interface ICashBoxRepository
    {
        IEnumerable<CashBoxResponse> GetCashBoxes();
        CashBoxResponse GetCashBox(Guid id);
        CashBoxResponse AddCashBox(CashBoxRequest request);
        void UpdateCashBox(Guid id, CashBoxRequest request);
        void DeleteCashBox(Guid id);
    }
}