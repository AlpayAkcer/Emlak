using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public bool Status { get; set; }

        public int CityID { get; set; }
        public virtual City City { get; set; }

        public virtual List<Neighbourhood> Neighbourhoods { get; set; }
    }
}
