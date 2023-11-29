using BookLibraryAPI.Domain.Enums;

namespace BookLibraryAPI.Domain.Models
{
    public class Book : BaseClass
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStateEnum State { get; set; }
        public string ISBN { get; set; }

    }
}
