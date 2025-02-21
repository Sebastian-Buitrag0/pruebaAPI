using Microsoft.EntityFrameworkCore;
using pruebaAPI.Models;

namespace pruebaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
