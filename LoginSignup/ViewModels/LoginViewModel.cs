using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginSignup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage ="Please enter Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
