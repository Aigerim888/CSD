using CSD.Web.Data;
using CSD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSD.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CSDContext _db;

        public CategoriesController(CSDContext db)
        {
            _db = db;
        }
        // GET: /Categories/Index
        public ActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(m => m.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }
        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_db.Categories.Where(x => x.ParentId == 0), "Id", "Name");
            return View();
        }
        // POST: Categories/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Add(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }



    }
}
