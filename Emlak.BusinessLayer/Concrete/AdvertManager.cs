using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class AdvertManager : GenericService<Advert>
    {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public void TAdd(Advert entity)
        {
            _advertRepository.Add(entity);
        }

        public void TDelete(Advert entity)
        {
            _advertRepository.Delete(entity);
        }

        public Advert TGetByID(int id)
        {
            return _advertRepository.GetByID(id);
        }

        public List<Advert> TGetListFilter(Expression<Func<Advert, bool>> filter)
        {
            return _advertRepository.GetListFilter(filter);
        }

        public List<Advert> TGetListAll()
        {
            return _advertRepository.GetListAll();
        }

        public void TUpdate(Advert entity)
        {
            _advertRepository.Update(entity);
        }
    }
}
