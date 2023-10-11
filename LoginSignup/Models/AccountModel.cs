using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginSignup.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [DisplayName("First Name *")]
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email *")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage ="Password is required")]
        [DisplayName("Password *")]
        public string Password { get; set; } = null!;
        [DisplayName("Confirm Password *")]
        [Required(ErrorMessage ="Needs to be entered")]
        public string ConfirmPassword { get; set; } = null!;
        [Required(ErrorMessage = "One must be selected")]
        public string Gender { get; set; } = null!;
        public bool Music { get; set; }
        public bool Sports { get; set; }
        public bool Travel { get; set; }
        public bool Movies { get; set; }
        [DisplayName("Source Of Income")]
        public SourceOfIncome SourceOfIncome { get; set; }
        public int Income { get; set; }
        [Required(ErrorMessage = "Must be between 18 and 100")]
        [Range(18,100,ErrorMessage ="Must be between 18 and 100")]
        public int Age { get; set; }

        public string? Bio { get; set; }
        public bool IsDeleted {  get; set; }
        public byte[]? Image { get; set; }
    }
    public enum SourceOfIncome
    {
        Employed,Freelancer,Other
    }
}
