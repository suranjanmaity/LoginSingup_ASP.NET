using LoginSignup.Models;
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
        public IActionResult AdminLogin(string Email,string Password)
        {
            var categoryFromDb = _db.Accounts.SingleOrDefault(o=>(o.Email==Email&&o.Password==Password));
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        public IActionResult CreateAccount() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(AccountModel obj)
        {
            if(ModelState.IsValid)
            {
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}