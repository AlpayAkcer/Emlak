using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class AdvertManager : AdvertService
    {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public void TAdd(Advert entity)
        {
            entity.Status = true;
            entity.AdvertDate = DateTime.Now;
            _advertRepository.Add(entity);
        }

        public void TDelete(Advert entity)
        {
            var delete = _advertRepository.GetByID(entity.AdvertID);
            entity.Status = false;
            //_advertRepository.Delete(entity);
            _advertRepository.Update(delete);
        }

        public Advert TGetByID(int id)
        {
            return _advertRepository.GetByID(id);
        }

        public List<Advert> TGetListFilter(Expression<Func<Advert, bool>> filter)
        {
            return _advertRepository.GetListFilter(filter);
        }

        public List<Advert> TGetList()
        {
            return _advertRepository.GetList();
        }

        public void TUpdate(Advert entity)
        {            
            _advertRepository.Update(entity);
        }

        public void CompleteDelete(Advert advert)
        {
            var delete = _advertRepository.GetByID(advert.AdvertID);
            _advertRepository.Delete(delete);
        }
    }
}
