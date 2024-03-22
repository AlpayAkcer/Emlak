using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Abstract
{
    public interface GenericService<T>
    {
        List<T> TGetListAll();
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        T TGetByID(int id);
        List<T> TGetListFilter(Expression<Func<T, bool>> filter);
        //lambda expression sorguları için 
    }
}
