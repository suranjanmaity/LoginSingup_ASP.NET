using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginSignup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountContext _db;
        public HomeController(ILogger<HomeController> logger, AccountContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(LoginViewModel logObj)
        {
            
            if (ModelState.IsValid)
            {
                var accFromDb = _db.Accounts.SingleOrDefault(catObj => (catObj.Email == logObj.Email && catObj.Password == logObj.Password));
                if (accFromDb == null)
                {
                    ModelState.AddModelError("Password","Email and password didn't match");
                    return View("Index", logObj);
                }
                return RedirectToAction("AdminLogin","Login",accFromDb);
            }
            return View("Index",logObj);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}