using Portfolio.Models;

namespace Portfolio.DataAccess.IRepository
{
    public interface ISubcategoryRepository : IBasicRepository<Subcategory>
    {
        void Update(Subcategory subcategory);
    }
}
