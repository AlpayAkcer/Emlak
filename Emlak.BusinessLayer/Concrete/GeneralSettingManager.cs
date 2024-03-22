using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class GeneralSettingManager : GenericService<GeneralSetting>
    {
        IGeneralSettingRepository _generalSettingRepository;

        public GeneralSettingManager(IGeneralSettingRepository generalSettingRepository)
        {
            _generalSettingRepository = generalSettingRepository;
        }

        public void TAdd(GeneralSetting entity)
        {
            _generalSettingRepository.Add(entity);
        }

        public void TDelete(GeneralSetting entity)
        {
            _generalSettingRepository.Delete(entity);
        }

        public GeneralSetting TGetByID(int id)
        {
            return _generalSettingRepository.GetByID(id);
        }

        public List<GeneralSetting> TGetListFilter(Expression<Func<GeneralSetting, bool>> filter)
        {
            return _generalSettingRepository.GetListFilter(filter);
        }

        public List<GeneralSetting> TGetListAll()
        {
            return _generalSettingRepository.GetListAll();
        }

        public void TUpdate(GeneralSetting entity)
        {
            _generalSettingRepository.Update(entity);
        }
    }
}
