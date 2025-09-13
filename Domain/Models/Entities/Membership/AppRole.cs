using Microsoft.AspNetCore.Identity;

namespace Shopping.Domain.Models.Entities.Membership
{
    public class AppRole : IdentityRole<int>
    {
        //public virtual ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>(); //
    }
}
