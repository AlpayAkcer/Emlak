using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Dto.AdvertDto
{
    public class AdvertAddDto
    {
        public string Title { get; set; }           // ilan başlığı
        public string Description { get; set; }     // ilan içeriği açıklaması
        public double Price { get; set; }           // ilan fiyatı
        public string Garage { get; set; }          // Garaj Var mı?
        public bool? Garden { get; set; }            // Bahçesi Var mı?
        public bool? FirePlace { get; set; }         // Isıtma Sistemi VAr mı?
        public bool? Furniture { get; set; }         // Mobilya Var mı?
        public bool? Pool { get; set; }              // Havuz Var mı?
        public bool? Teras { get; set; }             // Teras Var mı?
        public bool? AirCordinator { get; set; }     // Klima Var mı?
        public int NumberOfRoom { get; set; }       // Oda Sayısı
        public int BathOfRoomNumber { get; set; }   // Banyo Sayısı
        public bool? Credit { get; set; }            // Krediye Uygun mu? Değil mi?
        public int Area { get; set; }               // Mt2 alanı
        public int Floor { get; set; }              // Kat Sayısı
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

        public IEnumerable<IFormFile> ImageUrl { get; set; }   // İlan Resimleri
    }
}
