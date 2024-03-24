using System.Linq.Expressions;

namespace Emlak.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetList();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetByID(int id);
        List<T> GetListFilter(Expression<Func<T, bool>> filter);
        //lambda expression sorguları için 
    }
}
