using pruebaAPI.Models;
using System.Collections.Generic;

namespace pruebaAPI.Repositories
{
    public interface IProductoRepository
    {
        IEnumerable<ProductResponse> GetProducts();
        ProductResponse GetProduct(Guid id);
        void AddProduct(ProductRequest product);
        void UpdateProduct(Guid id, ProductRequest product);
        void DeleteProduct(Guid id);
    }
}