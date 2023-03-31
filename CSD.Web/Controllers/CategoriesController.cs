using Microsoft.AspNetCore.Mvc;

namespace CSD.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
