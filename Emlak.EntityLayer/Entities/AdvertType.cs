using System.ComponentModel.DataAnnotations;

namespace Emlak.EntityLayer.Entities
{
    public class AdvertType
    {
        [Key]
        public int AdvertTypeID { get; set; }
        public string AdvertTypeName { get; set; }
        public bool Status { get; set; }

        public int SituationID { get; set; }
        public virtual Situation Situation { get; set; }

        public virtual List<Advert> Adverts { get; set; }
    }
}
