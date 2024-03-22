using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class AdvertRepository : GenericRepository<Advert, EmlakDbContext>, IAdvertRepository
    {
        private EmlakDbContext _dbContext;
        public AdvertRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
