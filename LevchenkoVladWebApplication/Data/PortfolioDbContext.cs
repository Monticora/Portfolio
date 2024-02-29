using LevchenkoVladWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LevchenkoVladWebApplication.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<Category> CategoriesTable { get; set; }
        //Seed Category Table to DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = 1, Name = ".Net" },
                new Category { Id = 2, Name = "JS" } );
        }
    }
}
