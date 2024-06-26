﻿using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Emlak.DataAccessLayer.Concrete
{
    public class GenericRepository<T, TContext> : IRepository<T> where T : class, new() where TContext : class
    {
        private EmlakDbContext _dbContext = new EmlakDbContext();
        DbSet<T> _object;

        public GenericRepository(EmlakDbContext dbContext)
        {
            _dbContext = dbContext;
            _object = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _object.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetListFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public void Update(T entity)
        {
            _object.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
