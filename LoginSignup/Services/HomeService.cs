using LoginSignup.Data;
using LoginSignup.Models;
using System.Net.Mail;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace LoginSignup.Services
{
    
    public class HomeService : IHomeService
    {
        private readonly IHttpContextAccessor _context;
        private readonly AccountContext _db;
        public HomeService(IHttpContextAccessor context, AccountContext db)
        {
            _context = context;
            _db = db;
        }
        public bool IsValidLogin()
        {
            #pragma warning disable CS8602 // Rethrow to preserve stack details
            string? loginEmail = _context.HttpContext.Session.GetString("login");
            #pragma warning restore CS8602 // Rethrow to preserve stack details
            if(loginEmail == null || loginEmail == "")
            {
                return false;
            }
            return true;
        }
        public bool IsEmailExist(AccountModel account)
        {
            // to get old account email
            AccountModel accFromDb = _db.Accounts.SingleOrDefault(obj=>obj.Email==account.Email)!;
            if (accFromDb==null)
            {
                return false;
            }
            return true;
        }
        public bool ValidEmail(AccountModel account)
        {
            bool isValid = false;
            var host = account.Email.Split("@")[1];
            if (host.Split(".").Length>1 && host.Split(".").Length < 5)
            {
                var company = host.Split(".")[0];
                var domain = host.Split(".")[1];
                if(company.Length>2)
                {
                    if(domain.Length>=2 && domain.Length<=4)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
        public bool UpdatePartial(AccountModel account)
        {
            // to get old account details
            AccountModel accFromDb = _db.Accounts.Find(account.Id)!;
            accFromDb.FirstName = account.FirstName==null ? accFromDb.FirstName:account.FirstName;
            accFromDb.LastName = account.LastName ?? "";
            AccountModel? accFromDb2 = _db.Accounts.SingleOrDefault(obj=>obj.Email==account.Email);
            if (accFromDb2 == null || accFromDb.Email == account.Email)
            {
                accFromDb.Email = account.Email;
            }
            else
            {
                return false;
            }
            accFromDb.Age = account.Age;
            accFromDb.Gender = account.Gender;
            accFromDb.Movies = account.Movies;
            accFromDb.Travel = account.Travel;
            accFromDb.Music = account.Music;
            accFromDb.Sports = account.Sports;
            accFromDb.SourceOfIncome = account.SourceOfIncome;
            accFromDb.Income = account.Income;
            accFromDb.Bio = account.Bio ?? "";
            _db.Accounts.Update(accFromDb);
            _db.SaveChanges();
            return true;
        }
        public void SoftDelete(int id)
        {
            // to get old account details
            AccountModel accFromDb = _db.Accounts.Find(id)!;
            accFromDb.IsDeleted = true; 
            _db.Accounts.Update(accFromDb);
            _db.SaveChanges();
        }
    }
}
