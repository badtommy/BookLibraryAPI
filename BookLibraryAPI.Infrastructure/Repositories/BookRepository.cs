using BookLibraryAPI.Domain.Interfaces;
using BookLibraryAPI.Domain.Models;

namespace BookLibraryAPI.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(EFContext dbContext) : base(dbContext)
        {
        }

    }
}
