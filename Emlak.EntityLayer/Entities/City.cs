using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        public virtual List<District> Districts { get; set; }
    }
}
