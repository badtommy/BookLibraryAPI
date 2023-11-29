using BookLibraryAPI.AppLayer.Errors;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<OneOf<DeleteResult, IError>>
    {
        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
