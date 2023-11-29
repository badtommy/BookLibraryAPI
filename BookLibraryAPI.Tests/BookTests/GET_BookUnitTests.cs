using BookLibrary.Contracts.DTOs.Books;
using Newtonsoft.Json;
using System.Net;

namespace BookLibraryAPI.Tests.BookTests
{
    public partial class BookUnitTests : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public BookUnitTests(TestWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_GetAllBooks_ShouldReturnSuccessResponse()
        {
            var response = await _client.GetAsync("/api/Book/GetAllBooksAsync");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookDTO>>(responseString);

            Assert.NotNull(books);
            Assert.True(books.Count > 0);
        }

        [Theory]
        [InlineData("7cf6b5f9-5867-430b-ba0e-ba17a115e304")]
        [InlineData("7cf6b5f9-5867-430b-ba0e-ba17a115e302")]
        public async Task Get_GetBookById_ShouldReturnSuccessResponse(string id)
        {

            var bookId = new Guid(id);
            var response = await _client.GetAsync($"/api/Book/GetBookByIdAsync/{bookId}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.NotNull(book);
        }

        [Fact]
        public async Task Get_GetBookById_ShouldReturnNotFoundResponse()
        {
            var bookId = new Guid("b3d5d0a0-9a3a-4e8e-8e1a-0b9e2b5f4f1a");

            var response = await _client.GetAsync($"/api/Book/GetBookByIdAsync/{bookId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}