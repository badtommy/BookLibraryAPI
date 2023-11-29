namespace BookLibraryAPI.Domain.Interfaces
{
    public interface IBaseClass
    {
        Guid Id { get; set; }
        void SetUpdatedDate(DateTime date);
    }
}
