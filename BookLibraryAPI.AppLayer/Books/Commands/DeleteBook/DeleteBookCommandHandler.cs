using BookLibraryAPI.AppLayer.Books.Common;
using BookLibraryAPI.AppLayer.Errors;
using BookLibraryAPI.Domain.Interfaces;
using MediatR;
using OneOf;

namespace BookLibraryAPI.AppLayer.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : BaseHandler, IRequestHandler<DeleteBookCommand, OneOf<DeleteResult, IError>>
    {
        public DeleteBookCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OneOf<DeleteResult, IError>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await UnitOfWork.BookRepository.GetByAsync(x => x.Id == request.Id);

            if (book == null)
            {
                return new Error() { Message = $"The book with id {request.Id} was not found.", StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            UnitOfWork.BookRepository.Delete(book);

            await UnitOfWork.CommitAsync();

            return new DeleteResult() { Message = $"The book with id {request.Id} was deleted." };
        }
    }
}
