using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.DataAccess.IRepository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;

namespace LevchenkoVladWebApplication.Areas.Content.Controllers
{
    [Area("Content")]
    public class SubcategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubcategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int? id)
        {
            var subcategories = _unitOfWork.SubcategoryRepository.GetAll().Where(categoryId => categoryId.CategoryId == id).ToList();
            return View(subcategories);
        }
        public IActionResult CreateOrUpdate(int? id)
        {
            SubcategoryViewModel subcategoryViewModel = new SubcategoryViewModel()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                Subcategory = new Subcategory()
            };
            //creat part
            if (id == null || id == 0)
            {
                return View(subcategoryViewModel);
            }
            //update part
            else
            {
                subcategoryViewModel.Subcategory = _unitOfWork.SubcategoryRepository.GetFirstOrDefuoult(c => c.Id == id);

                return View(subcategoryViewModel);
            }
        }
        [HttpPost]
        public IActionResult CreateOrUpdate(SubcategoryViewModel subcategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (subcategoryViewModel.Subcategory.Id == 0)
                {
                    _unitOfWork.SubcategoryRepository.Add(subcategoryViewModel.Subcategory);
                    TempData["success"] = "Subcategory created successfully";
                }
                else
                {
                    _unitOfWork.SubcategoryRepository.Update(subcategoryViewModel.Subcategory);
                    TempData["success"] = "Subcategory updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index", new { id = subcategoryViewModel.Subcategory.CategoryId });
            }
            else
            {
                subcategoryViewModel.CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }
            return View(subcategoryViewModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Subcategory? subcategorFromDB = _unitOfWork.SubcategoryRepository.GetFirstOrDefuoult(item => item.Id == id);

            if (subcategorFromDB == null)
            {
                return NotFound();
            }
            return View(subcategorFromDB);
        }
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Subcategory? subcategoryFromDB = _unitOfWork.SubcategoryRepository.GetFirstOrDefuoult(item => item.Id == id);
            if (subcategoryFromDB == null)
            {
                return NotFound();
            }
            _unitOfWork.SubcategoryRepository.Delete(subcategoryFromDB);
            _unitOfWork.Save();

            TempData["success"] = "Subcategory deleted successfully";

            return RedirectToAction("Index", new { id = subcategoryFromDB.CategoryId });
        }
    }
}
