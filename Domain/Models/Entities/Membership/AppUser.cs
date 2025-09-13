using Microsoft.AspNetCore.Identity;

namespace Shopping.Domain.Models.Entities.Membership
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //public virtual ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>(); //
    }
}
