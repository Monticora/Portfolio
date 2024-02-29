using LevchenkoVladWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace LevchenkoVladWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PortfolioDbContext _databaseContext;
        public CategoryController(PortfolioDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var categoryList = _databaseContext.CategoriesTable.ToList();
            return View(categoryList);
        }
    }
}
