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
            if (loginEmail == null || loginEmail == "")
            {
                return false;
            }
            return true;
        }
        public bool IsEmailExist(AccountModel account)
        {
            // to get old account email
            AccountModel accFromDb = _db.Accounts.SingleOrDefault(obj => obj.Email == account.Email)!;
            if (accFromDb == null)
            {
                return false;
            }
            return true;
        }
        public bool ValidEmail(AccountModel account)
        {
            bool isValid = false;
            var host = account.Email.Split("@")[1];
            if (host.Split(".").Length > 1 && host.Split(".").Length < 5)
            {
                var company = host.Split(".")[0];
                var domain = host.Split(".")[1];
                if (company.Length > 2)
                {
                    if (domain.Length >= 2 && domain.Length <= 4)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
        public bool UpdatePartial(AccountModel account)
        {
            //AccountModel? accFromDb2 = _db.Accounts.SingleOrDefault(obj=>obj.Email==account.Email);

            // using linq
            var accFromDb2 = from acc in _db.Accounts
                             where acc.Email == account.Email
                             select new AccountModel
                             {
                                 Email = acc.Email,
                             };
            // to get old account details
            //AccountModel accFromDb = _db.Accounts.Find(account.Id)!;
            // using linq
            var accFromDb = from acc in _db.Accounts
                             where acc.Id == account.Id
                             select new AccountModel
                             {
                                 FirstName = account.FirstName ?? acc.FirstName,
                                 LastName = account.LastName ?? "",
                                 Email = (accFromDb2 == null || acc.Email == account.Email) ? account.Email : acc.Email,
                                 Gender = account.Gender,
                                 Music = account.Music,
                                 Sports = account.Sports,
                                 Movies = account.Movies,
                                 Travel = account.Travel,
                                 SourceOfIncome = account.SourceOfIncome,
                                 Income = account.Income,
                                 Age = account.Age,
                                 Bio = account.Bio??""
                             };

            _db.Accounts.Update(accFromDb.ElementAt(0));
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

        public void AddAccount(AccountModel obj)
        {
            _db.Accounts.Add(obj);
            _db.SaveChanges();
        }
    }
}
