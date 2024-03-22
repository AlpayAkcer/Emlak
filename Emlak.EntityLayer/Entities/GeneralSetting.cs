using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emlak.EntityLayer.Entities
{
    public class GeneralSetting
    {
        [Key]
        public int GeneralSettingID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageUrl { get; set; }

    }
}
