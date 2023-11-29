using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.Domain.Interfaces;
using MediatR;

namespace BookLibraryAPI.AppLayer.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : BaseHandler, IRequestHandler<GetAllBooksQuery, IEnumerable<BookResult>>
    {
        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<BookResult>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await UnitOfWork.BookRepository.GetAllAsync();

            return books.Select(b => new BookResult() { Book = b });
        }
    }
}
