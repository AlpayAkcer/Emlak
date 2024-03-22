using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class DistrictRepository : GenericRepository<District, EmlakDbContext>, IDistrictRepository
    {
        private EmlakDbContext _dbContext;
        public DistrictRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
