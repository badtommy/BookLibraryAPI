using BookLibraryAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookLibraryAPI.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, IBaseClass
    {

        protected readonly EFContext _dbContext;
        private readonly DbSet<T> _entitiySet;


        public Repository(EFContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();

        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Delete(T entity)
           => _dbContext.Remove(entity);

        public void DeleteById(Guid id)
        {
            _entitiySet.Remove(_entitiySet.Find(id));
        }

        public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _entitiySet.AsQueryable().AsNoTracking();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public T Update(T entity)
        {
            entity.SetUpdatedDate(DateTime.UtcNow);
            _entitiySet.Update(entity);
            return _entitiySet.Find(entity.Id);

        }
    }
}
