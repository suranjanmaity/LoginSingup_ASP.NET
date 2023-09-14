using LoginSignup.Data;
using LoginSignup.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginSignup.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AccountContext _db;
        public RegistrationController(AccountContext db)
        {
            _db = db;
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
                return RedirectToAction("Index","Home");
            }
            return View(obj);
        }
    }
}
