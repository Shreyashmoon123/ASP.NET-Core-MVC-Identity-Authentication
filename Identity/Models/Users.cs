using Microsoft.AspNetCore.Identity;
namespace Identity.Models
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
    }
}
