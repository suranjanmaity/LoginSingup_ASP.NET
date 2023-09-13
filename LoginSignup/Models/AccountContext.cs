using Microsoft.EntityFrameworkCore;

namespace LoginSignup.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountModel> Accounts { get; set; }
        public AccountContext(DbContextOptions options) : base(options)
        { 

        }
    }
}
