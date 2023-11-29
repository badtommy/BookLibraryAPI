using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<OneOf<BookResult, IError>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
