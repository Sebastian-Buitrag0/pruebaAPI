using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{
    public interface IProductoRepository
    {
        IEnumerable<ProductResponse> GetProducts();
        ProductResponse GetProduct(Guid id);
        ProductResponse AddProduct(ProductRequest request);
        void UpdateProduct(Guid id, ProductRequest request);
        void DeleteProduct(Guid id);
    }
}