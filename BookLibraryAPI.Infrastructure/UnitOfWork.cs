using BookLibraryAPI.Domain.Interfaces;
using BookLibraryAPI.Infrastructure.Repositories;

namespace BookLibraryAPI.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;
        private IBookRepository _bookRepository;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBookRepository BookRepository
        {
            get { return _bookRepository = _bookRepository ?? new BookRepository(_dbContext); }
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
