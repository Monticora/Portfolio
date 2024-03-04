using Portfolio.DataAccess.Data;
using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.IRepository;

namespace LevchenkoVladWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categoryList = _categoryRepository.GetAll().ToList();
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
                _categoryRepository.Add(category);
                _categoryRepository.Save();
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

            Category? categorFromDB = _categoryRepository.GetFirstOrDefuoult(item => item.Id == id);

            if (categorFromDB == null) 
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
                _categoryRepository.Update(category);
                _categoryRepository.Save();

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

            Category? categorFromDB = _categoryRepository.GetFirstOrDefuoult(item => item.Id == id);

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
            Category? category = _categoryRepository.GetFirstOrDefuoult(item => item.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category);
            _categoryRepository.Save();

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
