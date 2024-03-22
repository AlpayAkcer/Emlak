using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class GeneralSettingRepository : GenericRepository<GeneralSetting, EmlakDbContext>, IGeneralSettingRepository
    {
        private EmlakDbContext _dbContext;
        public GeneralSettingRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
