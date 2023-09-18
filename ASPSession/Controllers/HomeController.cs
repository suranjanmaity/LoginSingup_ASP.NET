using ASPSession.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _context;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _context.HttpContext.Session.SetString("UserName","John");
            _context.HttpContext.Session.SetInt32("UserId",50);
            return View();
        }

        public IActionResult Privacy()
        {
            string? user = _context.HttpContext.Session.GetString("UserName");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}