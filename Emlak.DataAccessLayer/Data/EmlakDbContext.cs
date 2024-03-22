using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Emlak.DataAccessLayer.Data
{
    public class EmlakDbContext : IdentityDbContext<UserAdmin>
    {
        //Birden fazla veritabanı kullanmak istersek o zaman json olarak diğer vt tanımlamak gerekecek.
        //UI katmanının içerisindeki appsetting.json içerisine connection tanımlıyoruz.
        public EmlakDbContext()
        {
            
        }
        public EmlakDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<AdvertType> AdvertTypes { get; set; }
        public DbSet<UserAdmin> UserAdmins { get; set; }

    }
}
