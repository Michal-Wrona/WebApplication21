using Microsoft.AspNetCore.Identity;

namespace WebApplication21.Core.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public AppRole Role { get; set; }
    }
}
