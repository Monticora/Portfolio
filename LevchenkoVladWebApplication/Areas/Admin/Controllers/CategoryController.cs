using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.IRepository;

namespace LevchenkoVladWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
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

            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categorFromDB = _unitOfWork.CategoryRepository.GetFirstOrDefuoult(item => item.Id == id);

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
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();

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

            Category? categorFromDB = _unitOfWork.CategoryRepository.GetFirstOrDefuoult(item => item.Id == id);

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
            Category? category = _unitOfWork.CategoryRepository.GetFirstOrDefuoult(item => item.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
