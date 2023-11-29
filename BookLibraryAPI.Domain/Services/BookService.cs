using BookLibraryAPI.Domain.Enums;
using BookLibraryAPI.Domain.Models;

namespace BookLibraryAPI.Domain.Services
{
    public class BookService
    {
        public BookService() { }

        public Book CreateBook(string title, string author, string isbn)
        {
            Book book = new Book();
            book.Title = title;
            book.Author = author;
            book.ISBN = "ISBN" + isbn;
            book.State = BookStateEnum.AVAILABLE;
            return book;
        }
    }
}
