using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models.ViewModels;

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
            var qaList = _unitOfWork.QARepository.GetAll(includeProperties:"Category").ToList();

            return View(qaList);
        }
        public IActionResult CreateOrUpdate(int? id)
        {
            QAViewModel qaViewModel = new QAViewModel()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                QA = new QuestionAndAnswer()
            };
            //creat part
            if(id == null || id == 0)
            {
                return View(qaViewModel);
            }
            //update part
            else
            {
                qaViewModel.QA = _unitOfWork.QARepository.GetFirstOrDefuoult(c => c.Id == id);

                return View(qaViewModel);
            }
        }
        [HttpPost]
        public IActionResult CreateOrUpdate(QAViewModel qaViewModel)
        {
            if (ModelState.IsValid)
            {
                if(qaViewModel.QA.Id == 0)
                {
                    _unitOfWork.QARepository.Add(qaViewModel.QA);
                    TempData["success"] = "QA created successfully";
                }
                else
                {
                    _unitOfWork.QARepository.Update(qaViewModel.QA);
                    TempData["success"] = "QA updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            else
            {
                qaViewModel.CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }
            return View(qaViewModel);
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
