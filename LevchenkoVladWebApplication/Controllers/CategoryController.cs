using Portfolio.DataAccess.Data;
using Portfolio.Models;
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
            //Custom validation that check do the name of the category have digit or not
            if (char.IsDigit(category.Name, 0))
            {
                ModelState.AddModelError("name", "The category name can't have digits!");
            }

            if(ModelState.IsValid)
            {
                _databaseContext.CategoriesTable.Add(category);
                _databaseContext.SaveChanges();

                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            Category? categorFromDB = _databaseContext.CategoriesTable.Where(obj => obj.Id == id).FirstOrDefault();

            if(categorFromDB == null) 
            {
                return NotFound();
            }
            return View(categorFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //Custom validation that check do the name of the category have digit or not
            if (char.IsDigit(category.Name, 0))
            {
                ModelState.AddModelError("name", "The category name can't have digits!");
            }

            if (ModelState.IsValid)
            {
                _databaseContext.CategoriesTable.Update(category);
                _databaseContext.SaveChanges();

                TempData["success"] = "Category updated successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categorFromDB = _databaseContext.CategoriesTable.Where(obj => obj.Id == id).FirstOrDefault();

            if (categorFromDB == null)
            {
                return NotFound();
            }
            return View(categorFromDB);
        }
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _databaseContext.CategoriesTable.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _databaseContext.CategoriesTable.Remove(category);
            _databaseContext.SaveChanges();

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
