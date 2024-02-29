using LevchenkoVladWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LevchenkoVladWebApplication.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<Category> CategoriesTable { get; set; }
    }
}
