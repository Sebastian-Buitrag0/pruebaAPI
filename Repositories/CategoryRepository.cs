using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public CategoryResponse GetCategory(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return null;

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public IEnumerable<CategoryResponse> GetCategories() =>
            _context.Categories.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });

        public void UpdateCategory(Guid id, CategoryRequest request)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                category.Name = request.Name;
                category.Description = request.Description;
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
    }
}