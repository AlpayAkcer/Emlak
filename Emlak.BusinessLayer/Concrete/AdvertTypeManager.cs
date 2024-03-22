using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class AdvertTypeManager : GenericService<AdvertType>
    {
        IAdvertTypeRepository _advertTyperepository;

        public AdvertTypeManager(IAdvertTypeRepository advertTyperepository)
        {
            _advertTyperepository = advertTyperepository;
        }

        public void TAdd(AdvertType entity)
        {
            _advertTyperepository.Add(entity);
        }

        public void TDelete(AdvertType entity)
        {
            _advertTyperepository.Delete(entity);
        }

        public AdvertType TGetByID(int id)
        {
            return _advertTyperepository.GetByID(id);
        }

        public List<AdvertType> TGetListFilter(Expression<Func<AdvertType, bool>> filter)
        {
            return _advertTyperepository.GetListFilter(filter);
        }

        public List<AdvertType> TGetListAll()
        {
            return _advertTyperepository.GetListAll();
        }

        public void TUpdate(AdvertType entity)
        {
            _advertTyperepository.Update(entity);
        }
    }
}
