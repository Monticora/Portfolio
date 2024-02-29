using LevchenkoVladWebApplication.Data;
using LevchenkoVladWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            //Custom validation that check do the name of the category have digit or not
            if (char.IsDigit(category.Name, 0))
            {
                ModelState.AddModelError("name", "The category name can't have digits!");
            }

            if(ModelState.IsValid)
            {
                _databaseContext.CategoriesTable.Add(category);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
