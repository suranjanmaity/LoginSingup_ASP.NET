using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginSignup.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IHomeService _service;
        public RegistrationController(IHomeService service)
        {
            _service = service;
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
            else if (!_service.ValidEmail(obj))
            {
                ModelState.AddModelError("Email", "This email is not valid! Use correct Email");
            }
            else if (_service.IsEmailExist(obj))
            {
                ModelState.AddModelError("Email", "Email is already used! Use another Email");
            }
            if (ModelState.IsValid)
            {
                _service.AddAccount(obj);
                TempData["success"] = "Account added successfully.";
                return RedirectToAction("AllAccounts","Home");
            }
            return View(obj);
        }
    }
}
