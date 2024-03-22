using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class Situation
    {
        [Key]
        public int SituationID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual List<AdvertType> AdvertTypes { get; set; }
    }
}
