using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class CityRepository : GenericRepository<City, EmlakDbContext>, ICityRepository
    {
        private EmlakDbContext _dbContext;
        public CityRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
