using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class SituationRepository : GenericRepository<Situation, EmlakDbContext>, ISituationRepository
    {
        private EmlakDbContext _dbContext;
        public SituationRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
