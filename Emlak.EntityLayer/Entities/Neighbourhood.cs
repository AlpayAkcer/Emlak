using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class Neighbourhood
    {
        [Key]
        public int NeighbourhoodID { get; set; }
        public string NeighbourhoodName { get; set; }
        public bool Status { get; set; }

        public int DistrictID { get; set; }
        public virtual District Districts { get; set; }
    }
}
