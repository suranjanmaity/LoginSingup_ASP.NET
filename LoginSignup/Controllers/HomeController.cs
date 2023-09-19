using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoginSignup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor? _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor? context)
        {
            _logger = logger;
            _context = context;
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}