using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class SituationManager : GenericService<Situation>
    {
        ISituationRepository _situationRepository;

        public SituationManager(ISituationRepository situationRepository)
        {
            _situationRepository = situationRepository;
        }

        public void TAdd(Situation entity)
        {
            _situationRepository.Add(entity);
        }

        public void TDelete(Situation entity)
        {
            _situationRepository.Delete(entity);
        }

        public Situation TGetByID(int id)
        {
            return _situationRepository.GetByID(id);
        }

        public List<Situation> TGetListFilter(Expression<Func<Situation, bool>> filter)
        {
            return _situationRepository.GetListFilter(filter);
        }

        public List<Situation> TGetListAll()
        {
            return _situationRepository.GetListAll();
        }

        public void TUpdate(Situation entity)
        {
            _situationRepository.Update(entity);
        }
    }
}
