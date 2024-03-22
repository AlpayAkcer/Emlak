using Microsoft.AspNetCore.Identity;

namespace Emlak.EntityLayer.Entities
{
    public class UserAdmin : IdentityUser
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public virtual List<Advert> Adverts { get; set; }
    }
}
