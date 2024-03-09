namespace Portfolio.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IQARepository QARepository { get; }
        ISubcategoryRepository SubcategoryRepository { get; }
        void Save();
    }
}
