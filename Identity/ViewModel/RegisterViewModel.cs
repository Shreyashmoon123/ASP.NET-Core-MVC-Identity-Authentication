using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Current Email Id")]
        [DisplayName("Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(40, MinimumLength = 8,
            ErrorMessage = "The {0} must be at least {2} and at most {1} characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Does not Match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}