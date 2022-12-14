using Microsoft.AspNetCore.Identity;

namespace WebApplication21.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
