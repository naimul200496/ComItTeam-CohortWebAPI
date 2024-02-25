using Microsoft.AspNetCore.Identity;

namespace FullStackReference.Service.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        //public string ?Role { get; set; }
    }
}
