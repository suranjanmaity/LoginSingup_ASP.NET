using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginSignup.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [DisplayName("First Name *")]
        [Required]
        public string FirstName { get; set; } = null!;
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Email *")]
        public string Email { get; set; } = null!;
        [Required]
        [DisplayName("Password *")]
        public string Password { get; set; } = null!;
        [DisplayName("Confirm Password *")]
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public List<string>? Hobbies { get; set; }
        [DisplayName("Source Of Income")]
        public SourceOfIncome SourceOfIncome { get; set; }
        public int Income { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; }
    }
    public enum SourceOfIncome
    {
        Employed,Freelancer,Other
    }
}
