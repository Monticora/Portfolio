using Microsoft.AspNetCore.Mvc;

namespace LevchenkoVladWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
