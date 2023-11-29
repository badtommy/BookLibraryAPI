using BookLibraryAPI.AppLayer.Books.Common;
using MediatR;

namespace BookLibraryAPI.AppLayer.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookResult>>
    {
    }
}
