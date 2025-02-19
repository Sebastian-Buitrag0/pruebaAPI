using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryResponse> GetCategories();
        CategoryResponse GetCategory(Guid id);
        CategoryResponse AddCategory(CategoryRequest request);
        void UpdateCategory(Guid id, CategoryRequest request);
        void DeleteCategory(Guid id);
    }
}