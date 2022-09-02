using Microsoft.AspNetCore.Mvc;
using WebProjectSaba.Data;
using WebProjectSaba.Models;

namespace WebProjectSaba.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> objUserList=_db.Users;
            return View(objUserList);
        }

        //GET
        public IActionResult CreateUser()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User obj)
        {
            if(obj.Name == obj.Email)
            {
                ModelState.AddModelError("CustomError", "Same Name");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult EditUser(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            } 
            var user = _db.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(User obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("CustomError", "Same Name");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                TempData["success"] = "Edited Succesfuly";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUserPOST(int? id)
        {
            var user = _db.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
