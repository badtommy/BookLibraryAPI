using BookLibrary.Contracts.DTOs.Books;
using BookLibraryAPI.Tests.HelpClasses;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BookLibraryAPI.Tests.BookTests
{
    public partial class BookUnitTests
    {
        [Theory]
        [InlineData("Sedmá kniha", "Autor", "123456789")]
        [InlineData("Kniha 2", "Author 2", "123456789")]
        [InlineData("Kniha 3", "Author 3", "123456789")]

        public async Task Post_CreateBook_ShouldReturnSuccessResponse(string title, string author, string isbn)
        {
            var newBook = new CreateBookDTO
            {
                Title = title,
                Author = author,
                ISBN = isbn
            };
            var json = JsonConvert.SerializeObject(newBook);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Book/CreateBookAsync", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var createdBook = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.NotNull(createdBook);

        }
        [Fact]
        public async Task Post_CreateBook_ShouldReturnBadISBNResponse()
        {
            var newBook = new CreateBookDTO
            {
                Title = "Nová Kniha",
                Author = "Autor",
                ISBN = "123456789ergtregdgdfgdfgflgflglfkgklfgklfkg"
            };
            var json = JsonConvert.SerializeObject(newBook);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Book/CreateBookAsync", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var errors = JsonConvert.DeserializeObject<ErrorsList>(responseString);

            Assert.Equal("ISBN nesmí být delší než 16 znaků.", errors.Errors[0]);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
