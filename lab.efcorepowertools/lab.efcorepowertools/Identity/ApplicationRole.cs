using Microsoft.AspNetCore.Identity;

namespace lab.efcorepowertools.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }

        public bool IsActive { get; set; }
    }
}
