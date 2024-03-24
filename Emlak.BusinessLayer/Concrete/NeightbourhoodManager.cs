using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class NeightbourhoodManager : NeightbourhoodService
    {
        INeighbourhoodRepository _neighbourhoodRepository;

        public NeightbourhoodManager(INeighbourhoodRepository neighbourhoodRepository)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
        }

        public void TAdd(Neighbourhood entity)
        {
            _neighbourhoodRepository.Add(entity);
        }

        public void TDelete(Neighbourhood entity)
        {
            _neighbourhoodRepository.Delete(entity);
        }

        public Neighbourhood TGetByID(int id)
        {
            return _neighbourhoodRepository.GetByID(id);
        }

        public List<Neighbourhood> TGetListFilter(Expression<Func<Neighbourhood, bool>> filter)
        {
            return _neighbourhoodRepository.GetListFilter(filter);
        }

        public List<Neighbourhood> TGetList()
        {
            return _neighbourhoodRepository.GetList();
        }

        public void TUpdate(Neighbourhood entity)
        {
            _neighbourhoodRepository.Update(entity);
        }
    }
}
