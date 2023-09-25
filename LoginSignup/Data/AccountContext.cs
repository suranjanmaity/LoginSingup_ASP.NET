using LoginSignup.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSignup.Data
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountModel> Accounts { get; set; }

        #pragma warning disable CS8618 // Rethrow to preserve stack details
        public AccountContext(DbContextOptions options) : base(options)
        {

        }
        #pragma warning restore CS8618 // Rethrow to preserve stack details
    }
}
