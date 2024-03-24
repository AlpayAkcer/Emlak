using Emlak.EntityLayer.Entities;

namespace Emlak.BusinessLayer.Abstract
{
    public interface AdvertService : GenericService<Advert>
    {
        void CompleteDelete(Advert advert);
    }
}
