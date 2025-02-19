using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<SaleResponse> GetSales();
        SaleResponse GetSale(Guid id);
        SaleResponse AddSale(SaleRequest request);
        void UpdateSale(Guid id, SaleRequest request);
        void DeleteSale(Guid id);
    }
}