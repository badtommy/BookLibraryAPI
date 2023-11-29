using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using BookLibraryAPI.Domain.Interfaces;
using BookLibraryAPI.Domain.Services;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : BaseHandler, IRequestHandler<CreateBookCommand, OneOf<BookResult, IError>>
    {
        private readonly BookService _bookService;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, BookService bookService) : base(unitOfWork)
        {
            _bookService = bookService;
        }

        public async Task<OneOf<BookResult, IError>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var book = _bookService.CreateBook(request.Title, request.Author, request.ISBN);

            var result = await UnitOfWork.BookRepository.AddAsync(book);

            await UnitOfWork.CommitAsync();

            return new BookResult() { Book = result };
        }
    }
}
