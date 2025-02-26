using System.Linq.Expressions;

namespace InfrastructureLayer.DataAccess.Repositories.Common
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}