using Microsoft.AspNetCore.Identity;

namespace WebApplication21.Core.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
