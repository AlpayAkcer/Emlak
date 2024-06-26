﻿using Microsoft.AspNetCore.Identity;

namespace Emlak.EntityLayer.Entities
{
    public class UserAdmin : IdentityUser
    {
        public string FullName { get; set; }

        public virtual List<Advert> Adverts { get; set; }
    }
}
