using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emlak.EntityLayer.Entities
{
    public class Images
    {
        [Key]
        public int ImagesID { get; set; }
        public string ImageName { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public IFormFile ImageUrl { get; set; }
        public int AdvertID { get; set; }

        public virtual Advert Advert { get; set; }
    }
}
