using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using BookLibraryAPI.Domain.Enums;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<OneOf<BookResult, IError>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStateEnum State { get; set; }
        public string ISBN { get; set; }
        public Guid Id { get; set; }


    }
}
