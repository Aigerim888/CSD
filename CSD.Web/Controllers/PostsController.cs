using CSD.Web.Data;
using Microsoft.AspNetCore.Mvc;
using CSD.Web.Models;
using Microsoft.Identity.Client;

namespace CSD.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly CSDContext _db;
        public PostsController(CSDContext db)
        {
            _db= db;    
        }
        public IActionResult Index()
        {
          List <Post> postes = _db.Posts.ToList(); 
          return View(postes);
        }
  
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
            {
                _db.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _db.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {

                return NotFound();
            }
            return View(post);

        }
        public IActionResult Edit(int id)
        {
            var post = _db.Posts.Find(id);
            if(post ==null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if(post== null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Update(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
            
        }
        public IActionResult Delete(int id)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Id == id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var post = _db.Posts.Find(id);
            if(post!=null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
