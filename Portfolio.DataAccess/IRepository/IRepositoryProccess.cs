using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.IRepository
{
    public interface IRepositoryProccess<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetFirstOrDefuoult(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Delete(T item);
    }
}
