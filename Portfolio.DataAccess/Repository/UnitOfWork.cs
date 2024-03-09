using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PortfolioDbContext _portfolioDbContext;
        public ICategoryRepository CategoryRepository { get; private set; }
        public ISubcategoryRepository SubcategoryRepository { get; private set; }

        public IQARepository QARepository { get; private set; }
        public UnitOfWork(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
            CategoryRepository = new CategoryRepository(portfolioDbContext);
            SubcategoryRepository = new SubcategoryRepository(portfolioDbContext);
            QARepository = new QARepository(portfolioDbContext);
        }
        public void Save()
        {
            _portfolioDbContext.SaveChanges();
        }
    }
}
    