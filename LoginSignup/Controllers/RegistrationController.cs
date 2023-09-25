using LoginSignup.Data;
using LoginSignup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginSignup.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AccountContext _db;
        private readonly IHttpContextAccessor _context;
        public RegistrationController(AccountContext db, IHttpContextAccessor context)
        {
            _db = db;
            _context = context;
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(AccountModel obj)
        {
            if(obj.Password != obj.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Must be same Password");
            }
            else if (!(_db.Accounts.SingleOrDefault(accObj => (accObj.Email == obj.Email)) == null))
            {
                ModelState.AddModelError("Email", "This email address already exists! Use another Email");
            }
            if (ModelState.IsValid)
            {
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                #pragma warning disable CS8602 // Rethrow to preserve stack details
                if (_context.HttpContext.Session.GetString("login") != null &&
                    _context.HttpContext.Session.GetString("login") != "")
                #pragma warning restore CS8602 // Rethrow to preserve stack details
                {
                    return RedirectToAction("AllAccounts","Home");
                }
                return RedirectToAction("Index","Login");
            }
            return View(obj);
        }
    }
}
