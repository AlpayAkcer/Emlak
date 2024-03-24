namespace Emlak.Dto.AdvertDto
{
    public class AdvertListDto
    {
        public int AdvertID { get; set; }
        public string Title { get; set; }           // ilan başlığı
        public string Description { get; set; }     // ilan içeriği açıklaması
        public double Price { get; set; }           // ilan fiyatı
        public string Garage { get; set; }          // Garaj Var mı?
        public bool Garden { get; set; }            // Bahçesi Var mı?
        public bool FirePlace { get; set; }         // Isıtma Sistemi VAr mı?
        public bool Furniture { get; set; }         // Mobilya Var mı?
        public bool Pool { get; set; }              // Havuz Var mı?
        public bool Teras { get; set; }             // Teras Var mı?
        public bool AirCordinator { get; set; }     // Klima Var mı?
        public int NumberOfRoom { get; set; }       // Oda Sayısı
        public int BathOfRoomNumber { get; set; }   // Banyo Sayısı
        public bool Credit { get; set; }            // Krediye Uygun mu? Değil mi?
        public int Area { get; set; }               // Mt2 alanı
        public int Floor { get; set; }              // Kat Sayısı
        public DateTime AdvertDate { get; set; }    // İlanın Eklenme Tarihi
        public string CityName { get; set; }             // Şehir 
        public string UserName { get; set; }     // Identity yapısı kullanılacak        
        public bool Status { get; set; }            // Aktif Pasif Durum Kontrolü
    }
}
