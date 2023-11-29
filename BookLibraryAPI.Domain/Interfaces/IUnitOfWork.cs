namespace BookLibraryAPI.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        Task CommitAsync();
    }
}
