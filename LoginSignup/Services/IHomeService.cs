using LoginSignup.Models;

namespace LoginSignup.Services
{
    public interface IHomeService
    {
        public bool IsValidLogin();
        public bool ValidEmail(AccountModel account);
        public bool UpdatePartial(AccountModel account);

    }
}
