using BookLibrary.Contracts.DTOs.Books;
using BookLibraryAPI.Tests.HelpClasses;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BookLibraryAPI.Tests.BookTests
{
    public partial class BookUnitTests
    {
        [Fact]
        public async Task Put_UpdateBook_ShouldReturnSuccessResponse()
        {
            var bookId = new Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e304");
            var updateBook = new BookDTO
            {
                Title = "Aktulizovana kniha",
                Author = "Autor",
                ISBN = "123456789"
            };
            var json = JsonConvert.SerializeObject(updateBook);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/Book/UpdateBookByIdAsync/{bookId}", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var updatedBook = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.NotNull(updatedBook);
            Assert.Equal("Aktulizovana kniha", updatedBook.Title);
            Assert.Equal("Autor", updatedBook.Author);
        }

        [Fact]
        public async Task Put_UpdateBook_ShouldReturnNotFoundResponse()
        {
            var bookId = new Guid("b3d5d0a0-9a3a-4e8e-8e1a-0b9e2b5f4f1a");
            var updateBook = new BookDTO
            {
                Title = "Aktulizovana kniha",
                Author = "Autor",
                ISBN = "123456789"
            };
            var json = JsonConvert.SerializeObject(updateBook);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/Book/UpdateBookByIdAsync/{bookId}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Put_UpdateBook_ShouldReturnBadISBNResponse()
        {
            var bookId = new Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e304");
            var updateBook = new BookDTO
            {
                Title = "Aktulizovana kniha",
                Author = "Autor",
                ISBN = "123456789ergtregdgdfgdfgflgflglfkgklfgklfkg"
            };
            var json = JsonConvert.SerializeObject(updateBook);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/Book/UpdateBookByIdAsync/{bookId}", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var errors = JsonConvert.DeserializeObject<ErrorsList>(responseString) ?? new ErrorsList();

            Assert.Equal("ISBN nesmí být delší než 16 znaků.", errors.Errors[0]);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
