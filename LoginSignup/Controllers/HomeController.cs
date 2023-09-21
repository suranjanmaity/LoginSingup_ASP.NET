using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;

namespace LoginSignup.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor? _context;
        private readonly AccountContext _db;

        public HomeController(IHttpContextAccessor? context,AccountContext db)
        {
            _context = context;
            _db = db;
        }
        public IActionResult Home(AccountModel account)
        {
                #pragma warning disable CS8602 // Rethrow to preserve stack details
            if (_context.HttpContext.Session.GetString("login") != null &&
                _context.HttpContext.Session.GetString("login") != "" &&
                _context.HttpContext.Session.GetString("login") == account.Email)
                #pragma warning restore CS8602 // Rethrow to preserve stack details
            {
                return View(account);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AllAccounts()
        {
                #pragma warning disable CS8602 // Rethrow to preserve stack details
            if (_context.HttpContext.Session.GetString("login") != null &&
                _context.HttpContext.Session.GetString("login") != "")
                #pragma warning restore CS8602 // Rethrow to preserve stack details
            {
                return View(_db.Accounts.ToList());
            }
            return RedirectToAction("Index", "Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}