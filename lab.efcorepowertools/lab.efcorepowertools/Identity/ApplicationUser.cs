using Microsoft.AspNetCore.Identity;

namespace lab.efcorepowertools.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public int Age { get; set; }
    }

}
