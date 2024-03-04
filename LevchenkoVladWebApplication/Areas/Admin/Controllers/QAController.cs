using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LevchenkoVladWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QAController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QAController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var qaList = _unitOfWork.QARepository.GetAll().ToList();

            return View(qaList);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;

            return View();
        }
        [HttpPost]
        public IActionResult Create(QuestionAndAnswer qa)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.QARepository.Add(qa);
                _unitOfWork.Save();
                TempData["success"] = "QA created successfully";

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

            QuestionAndAnswer? qaFromDB = _unitOfWork.QARepository.GetFirstOrDefuoult(item => item.Id == id);

            if (qaFromDB == null)
            {
                return NotFound();
            }
            return View(qaFromDB);
        }
        [HttpPost]
        public IActionResult Edit(QuestionAndAnswer qa)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.QARepository.Update(qa);
                _unitOfWork.Save();

                TempData["success"] = "QA updated successfully";

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

            QuestionAndAnswer? qaFromDB = _unitOfWork.QARepository.GetFirstOrDefuoult(item => item.Id == id);

            if (qaFromDB == null)
            {
                return NotFound();
            }
            return View(qaFromDB);
        }
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            QuestionAndAnswer? qa = _unitOfWork.QARepository.GetFirstOrDefuoult(item => item.Id == id);
            if (qa == null)
            {
                return NotFound();
            }
            _unitOfWork.QARepository.Delete(qa);
            _unitOfWork.Save();

            TempData["success"] = "QA deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
