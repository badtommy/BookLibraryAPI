using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<OneOf<BookResult, IError>>
    {
        public GetBookQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
