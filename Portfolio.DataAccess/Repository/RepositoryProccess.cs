using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using System.Linq.Expressions;

namespace Portfolio.DataAccess.Repository
{
    public class RepositoryProccess<T> : IRepositoryProccess<T> where T : class
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        internal DbSet<T> dbSet;

        public RepositoryProccess(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
            this.dbSet = _portfolioDbContext.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefuoult(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
