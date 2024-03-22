using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class DistrictManager : GenericService<District>
    {
        IDistrictRepository _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public void TAdd(District entity)
        {
            _districtRepository.Add(entity);
        }

        public void TDelete(District entity)
        {
            _districtRepository.Delete(entity);
        }

        public District TGetByID(int id)
        {
            return _districtRepository.GetByID(id);
        }

        public List<District> TGetListFilter(Expression<Func<District, bool>> filter)
        {
            return _districtRepository.GetListFilter(filter);
        }

        public List<District> TGetListAll()
        {
            return _districtRepository.GetListAll();
        }

        public void TUpdate(District entity)
        {
            _districtRepository.Update(entity);
        }
    }
}
