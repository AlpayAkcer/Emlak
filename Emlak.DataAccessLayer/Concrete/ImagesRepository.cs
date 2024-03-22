using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class ImagesRepository : GenericRepository<Images, EmlakDbContext>, IImagesRepository
    {
        private EmlakDbContext _dbContext;
        public ImagesRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
