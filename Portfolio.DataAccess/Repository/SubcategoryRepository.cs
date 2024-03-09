using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using Portfolio.Models;

namespace Portfolio.DataAccess.Repository
{
    public class SubcategoryRepository : RepositoryProccess<Subcategory>, ISubcategoryRepository
    {
        private PortfolioDbContext _portfolioDbContext;
        public SubcategoryRepository(PortfolioDbContext portfolioDbContext) : base(portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }
        public void Update(Subcategory subcategory)
        {
            _portfolioDbContext.SubcategoriesTable.Update(subcategory);
        }
    }
}
