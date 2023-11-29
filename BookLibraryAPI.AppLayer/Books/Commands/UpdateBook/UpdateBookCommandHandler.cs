using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using BookLibraryAPI.Domain.Interfaces;
using BookLibraryAPI.Domain.Services;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : BaseHandler, IRequestHandler<UpdateBookCommand, OneOf<BookResult, IError>>
    {
        private readonly BookService _bookService;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, BookService bookService) : base(unitOfWork)
        {
            _bookService = bookService;
        }

        public async Task<OneOf<BookResult, IError>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await UnitOfWork.BookRepository.GetByAsync(x => x.Id == request.Id);

            if (book == null)
            {
                return new Error() { Message = $"The book with id {request.Id} was not found.", StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;

            var result = UnitOfWork.BookRepository.Update(book);

            await UnitOfWork.CommitAsync();

            return new BookResult() { Book = result };
        }
    }
}
