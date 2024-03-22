using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class CityManager : GenericService<City>
    {
        ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void TAdd(City entity)
        {
            _cityRepository.Add(entity);
        }

        public void TDelete(City entity)
        {
            _cityRepository.Delete(entity);
        }

        public City TGetByID(int id)
        {
            return _cityRepository.GetByID(id);
        }

        public List<City> TGetListFilter(Expression<Func<City, bool>> filter)
        {
            return _cityRepository.GetListFilter(filter);
        }

        public List<City> TGetListAll()
        {
            return _cityRepository.GetListAll();
        }

        public void TUpdate(City entity)
        {
            _cityRepository.Update(entity);
        }
    }
}
