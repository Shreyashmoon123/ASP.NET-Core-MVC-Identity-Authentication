using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Please Enter Correct Email")]
        [DisplayName("Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("")]
        public Boolean Rememberme { get; set; }
    }
}
