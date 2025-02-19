

    using pruebaAPI.Models;

    namespace pruebaAPI.Interfaces
    {
        public interface IProductSale
        {
            IEnumerable<ProductSaleResponse> GetProductSales();
            ProductSaleResponse GetProductSale(Guid id);
            ProductSaleResponse AddProductSale(ProductSaleRequest request);
            void UpdateProductSale(Guid id, ProductSaleRequest request);
            void DeleteProductSale(Guid id);
        }
    }
