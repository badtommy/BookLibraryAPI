using BookLibraryAPI.Domain.Interfaces;

namespace BookLibraryAPI.Domain.Models
{
    public class BaseClass : IBaseClass
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedAt { get; set; } = DateTime.UtcNow;

        public void SetUpdatedDate(DateTime date)
        {
            LastModifiedAt = date;
        }
    }
}
