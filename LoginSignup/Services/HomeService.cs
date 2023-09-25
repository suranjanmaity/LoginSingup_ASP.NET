using LoginSignup.Data;
using LoginSignup.Models;

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
        public bool ValidEmail(AccountModel account)
        {
            if (account != null)
            {
                // to get old account email
                AccountModel accFromDb = _db.Accounts.Find(account.Id)!;
                if (accFromDb != null)
                {
                    // to check the email is already been used or not
                    AccountModel accFromDbEmail = _db.Accounts.FirstOrDefault(obj => obj.Email == account.Email)!;
                    if (account.Email == accFromDb.Email || accFromDbEmail == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool UpdatePartial(AccountModel account)
        {
            // to get old account details
            AccountModel accFromDb = _db.Accounts.Find(account.Id)!;
            accFromDb.FirstName = account.FirstName;
            accFromDb.LastName = account.LastName ?? "";
            accFromDb.Password = account.ConfirmPassword;//for updating new pass
            accFromDb.Email = account.Email;
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
    }
}
