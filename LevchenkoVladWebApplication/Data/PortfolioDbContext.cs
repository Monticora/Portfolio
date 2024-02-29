using Microsoft.EntityFrameworkCore;

namespace LevchenkoVladWebApplication.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
    }
}
