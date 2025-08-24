using Microsoft.AspNetCore.Identity;

namespace Shopping.Domain.Models.Entities.Membership
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
