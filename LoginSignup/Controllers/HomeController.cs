
using LoginSignup.Data;
using LoginSignup.Models;
using LoginSignup.Services;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LoginSignup.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor? _context;
        private readonly AccountContext _db;
        private readonly IHomeService _service;
        public HomeController(IHttpContextAccessor? context,AccountContext db, IHomeService service)
        {
            _context = context;
            _db = db;
            _service = service;
        }
        public IActionResult Home(AccountModel account)
        {
            if (_service.IsValidLogin())
            {
                if (account.Email == null)
                {
            #pragma warning disable CS8600 // Rethrow to preserve stack details
            #pragma warning disable CS8602 // Rethrow to preserve stack details
                    account = _db.Accounts.SingleOrDefault(obj => obj.Email == _context.HttpContext.Session.GetString("login")!);
            #pragma warning restore CS8600 // Rethrow to preserve stack details
            #pragma warning restore CS8602 // Rethrow to preserve stack details
                }
                return View(account);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AllAccounts()
        {
            if (_service.IsValidLogin())
            {
                return View( _db.Accounts.ToList());
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult MyDetails()
        {
            if (_service.IsValidLogin())
            {
#pragma warning disable CS8602 // Rethrow to preserve stack details

                return View(_db.Accounts.SingleOrDefault(obj=>obj.Email==_context.HttpContext.Session.GetString("login")));
#pragma warning restore CS8602 // Rethrow to preserve stack details
            }
            return RedirectToAction("Index", "Login");
        }
        //public IActionResult UpdatePartial(int? id)
        //{
        //    if (_service.IsValidLogin())
        //    {
        //        AccountModel account = _db.Accounts.SingleOrDefault(o => o.Id == id)!;
        //        if (account!=null)
        //        {
        //            return View("_UpdatePartial",account);
        //        }
        //    }
        //    return RedirectToAction("Index", "Login");
        //}
        [HttpPost]
        public IActionResult UpdatePartial(AccountModel account)
        {

            if (_service.IsValidLogin())
            {
                if (account != null)
                {
                    AccountModel accFromDb = _db.Accounts.SingleOrDefault(obj => obj.Id == account.Id)!;
                    if (account.Password == account.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "Must not be same Password");
                    }
                    if (!_service.ValidEmail(account))
                    {
                        ModelState.AddModelError("Email", "This email address already exists! Use another Email");
                    }
                    if (ModelState.IsValid)
                    {
                        if (_service.UpdatePartial(account))
                        {
                            return RedirectToAction("AllAccounts", _db.Accounts.ToList());
                        }
                    }
                    TempData["Id"]=account.Id;
                    return View("AllAccounts", _db.Accounts.ToList());
                }
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