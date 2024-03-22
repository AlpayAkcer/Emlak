using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class NeighbourhoodRepository : GenericRepository<Neighbourhood, EmlakDbContext>, INeighbourhoodRepository
    {
        private EmlakDbContext _dbContext;
        public NeighbourhoodRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
