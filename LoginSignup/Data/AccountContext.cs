using LoginSignup.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSignup.Data
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountModel> Accounts { get; set; }
        public AccountContext(DbContextOptions options) : base(options)
        {

        }
    }
}
