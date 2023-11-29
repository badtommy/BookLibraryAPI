using System.Linq.Expressions;

namespace BookLibraryAPI.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        T Update(T entity);
        void DeleteById(Guid id);
        void Delete(T entity);
    }
}
