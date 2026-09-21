using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModel
{
    public class ChangePasswordViewModel
    {

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Current Email Id")]
        [DisplayName("Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Current Password")]
        [DataType(DataType.Password)]
        [DisplayName("Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [StringLength(40, MinimumLength = 8,
            ErrorMessage = "The {0} must be at least {2} and at most {1} characters long")]
        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Does not Match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        public string ConfirmPassword { get; set; }
    }
}
