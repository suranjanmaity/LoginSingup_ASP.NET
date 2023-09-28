using LoginSignup.Models;

namespace LoginSignup.Services
{
    public interface IHomeService
    {
        public bool IsValidLogin();
        public bool ValidEmail(AccountModel account);
        public bool IsEmailExist(AccountModel account);
        public bool UpdatePartial(AccountModel account);
        public void SoftDelete(int id);
    }
}