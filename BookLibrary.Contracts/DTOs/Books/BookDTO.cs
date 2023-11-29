using BookLibraryAPI.Domain.Enums;

namespace BookLibrary.Contracts.DTOs.Books
{
    public class BookDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public BookStateEnum BookState { get; set; }
    }
}
