using LevchenkoVladWebApplication.Data;
using LevchenkoVladWebApplication.Models;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _databaseContext.CategoriesTable.Add(category);
            _databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
