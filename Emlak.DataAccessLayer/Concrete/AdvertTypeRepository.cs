﻿using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Emlak.EntityLayer.Entities;

namespace Emlak.DataAccessLayer.Concrete
{
    public class AdvertTypeRepository : GenericRepository<AdvertType, EmlakDbContext>, IAdvertTypeRepository
    {
        private EmlakDbContext _dbContext;

        public AdvertTypeRepository(EmlakDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       
    }
}
