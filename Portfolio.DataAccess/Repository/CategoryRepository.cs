using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using Portfolio.Models;
using System.Linq.Expressions;

namespace Portfolio.DataAccess.Repository
{
    public class CategoryRepository : RepositoryProccess<Category>, ICategoryRepository
    {
        private PortfolioDbContext _portfolioDbContext;
        public CategoryRepository(PortfolioDbContext portfolioDbContext) : base(portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }
        public void Update(Category category)
        {
            _portfolioDbContext.CategoriesTable.Update(category);
        }
    }
}
