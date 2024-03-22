using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class Images
    {
        [Key]
        public int ImagesID { get; set; }
        public string ImageName { get; set; }
        public bool Status { get; set; }
        public int AdvertID { get; set; }

        public virtual Advert Advert { get; set; }
    }
}
