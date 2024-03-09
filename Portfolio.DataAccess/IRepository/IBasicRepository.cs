using System.Linq.Expressions;

namespace Portfolio.DataAccess.IRepository
{
    public interface IBasicRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        T GetFirstOrDefuoult(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T item);
        void Delete(T item);
    }
}
