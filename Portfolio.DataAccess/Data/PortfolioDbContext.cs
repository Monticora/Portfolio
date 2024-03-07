using Portfolio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.DataAccess.Data
{
    public class PortfolioDbContext : IdentityDbContext<IdentityUser>
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<QuestionAndAnswer> QuestionAndAnswersTable { get; set; }
        //Seed Category Table to DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for identity avoid error
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = 1, Name = ".Net" },
                new Category { Id = 2, Name = "JS" } );
        }
    }
}
