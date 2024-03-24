using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emlak.EntityLayer.Entities
{
    public class Advert
    {
        public Advert()
        {
            Images = new List<Images>();
        }

        [Key]
        public int AdvertID { get; set; }
        public string Title { get; set; }           // ilan başlığı
        public string Description { get; set; }     // ilan içeriği açıklaması
        public double Price { get; set; }           // ilan fiyatı
        public string Garage { get; set; }          // Garaj Var mı?
        public bool Garden { get; set; } = false;       // Bahçesi Var mı?
        public bool FirePlace { get; set; } = false;       // Isıtma Sistemi VAr mı?
        public bool Furniture { get; set; } = false;       // Mobilya Var mı?
        public bool Pool { get; set; } = false;        // Havuz Var mı?
        public bool Teras { get; set; } = false;       // Teras Var mı?
        public bool AirCordinator { get; set; } = false;     // Klima Var mı?
        public int NumberOfRoom { get; set; }       // Oda Sayısı
        public int BathOfRoomNumber { get; set; }   // Banyo Sayısı
        public bool Credit { get; set; } = false;       // Krediye Uygun mu? Değil mi?
        public int Area { get; set; } = 0;         // Mt2 alanı
        public int Floor { get; set; } = 0;         // Kat Sayısı
        public DateTime AdvertDate { get; set; }    // İlanın Eklenme Tarihi
        public string Address { get; set; }         // İlan Adresi
        public int CityID { get; set; }             // Şehir 
        public int DistrictID { get; set; }         // İlçe
        public int NeighbourhoodID { get; set; }    // Mahalle Semt
        public string PhoneNumber { get; set; }     // İlan Telefon      
        public int SituationID { get; set; }        // Binanın Durumu /Seçenekli
        public int AdvertTypeID { get; set; }       // Türü - Ev - Arsa - Bina        
        public string UserAdminID { get; set; }     // Identity yapısı kullanılacak        
        public bool Status { get; set; }            // Aktif Pasif Durum Kontrolü

        [NotMapped]
        public IEnumerable<IFormFile> ImageUrl { get; set; }   // İlan Resimleri


        //Maping        
        public virtual Neighbourhood Neighbourhood { get; set; }
        public virtual AdvertType AdvertType { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }
        public virtual List<Images> Images { get; set; }
    }
}
