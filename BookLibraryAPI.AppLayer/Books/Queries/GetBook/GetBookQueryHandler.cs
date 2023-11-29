using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using BookLibraryAPI.Domain.Interfaces;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Queries.GetBook
{
    public class GetBookQueryHandler : BaseHandler, IRequestHandler<GetBookQuery, OneOf<BookResult, IError>>
    {
        public GetBookQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<OneOf<BookResult, IError>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return new Error() { Message = $"The book with id {request.Id} was not found.", StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            var book = await UnitOfWork.BookRepository.GetByAsync(x => x.Id == request.Id);

            if (book == null)
            {
                return new Error() { Message = $"The book with id {request.Id} was not found.", StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            return new BookResult() { Book = book };
        }
    }
}
