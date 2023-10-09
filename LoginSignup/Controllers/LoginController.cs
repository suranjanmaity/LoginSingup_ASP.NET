using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace LoginSignup.Controllers
{
    public class LoginController : Controller
    {
        private readonly AccountContext _db;
        private readonly IHttpContextAccessor? _context;
        public LoginController( AccountContext db, IHttpContextAccessor? context)
        {
            _db = db;
            _context = context;
        }
        public IActionResult Index()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _context.HttpContext.Session.SetString("login", "");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            TempData.Clear();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var accFromDb = _db.Accounts.SingleOrDefault(DbObj => (DbObj.Email == obj.Email && DbObj.Password == obj.Password));
                if (accFromDb == null)
                {
                    ModelState.AddModelError("Password", "Email and password didn't match");
                    return View(obj);
                }
                // to restrict soft deleted email login
                //if (accFromDb.IsDeleted)
                //{
                //    ModelState.AddModelError("Email", "Account linked to this Email has been deleted!");
                //    return View(obj);
                //}
                    #pragma warning disable CS8602 // Rethrow to preserve stack details
                    _context.HttpContext.Session.SetString("login", accFromDb.Email);
                    #pragma warning restore CS8602 // Rethrow to preserve stack details
                    TempData["login"]=accFromDb.Email;
                    return RedirectToAction("Home","Home",accFromDb);
            }
            return View(obj);
        }
        public IActionResult Logout()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _context.HttpContext.Session.SetString("login", "");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            TempData.Clear();
            return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
