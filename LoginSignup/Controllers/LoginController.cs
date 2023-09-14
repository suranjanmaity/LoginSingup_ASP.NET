using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSignup.Controllers
{
    public class LoginController : Controller
    {
        private readonly AccountContext _db;
        public LoginController( AccountContext db)
        {
            _db = db;
        }
        public IActionResult AdminLogin(AccountModel account)
        {
            return View(account);
        }
        //public IActionResult Logout()
        //{
        //    Session.Clear();
        //    Response.Redirect("Index");
        //}
    }
}
