using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public interface ISalesRepository
    {
        IEnumerable<SaleResponse> GetSales();
        SaleResponse GetSale(Guid id);
        void AddSale(SaleRequest request);
        void UpdateSale(Guid id, SaleRequest request);
        void Delete(Guid id);
    }
}