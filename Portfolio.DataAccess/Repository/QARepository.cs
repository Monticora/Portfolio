using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.IRepository;
using Portfolio.Models;
namespace Portfolio.DataAccess.Repository
{
    public class QARepository : RepositoryProccess<QuestionAndAnswer>, IQARepository
    {
        private PortfolioDbContext _portfolioDbContext;
        public QARepository(PortfolioDbContext portfolioDbContext) : base(portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }
        public void Update(QuestionAndAnswer qa)
        {
            _portfolioDbContext.QuestionAndAnswersTable.Update(qa);
        }
    }
}
