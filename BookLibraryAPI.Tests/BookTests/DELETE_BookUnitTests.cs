using System.Net;

namespace BookLibraryAPI.Tests.BookTests
{
    public partial class BookUnitTests
    {
        [Fact]
        public async Task Delete_DeleteBook_ShouldReturnSuccessResponse()
        {
            var bookId = new Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e303");

            var response = await _client.DeleteAsync($"/api/Book/DeleteBookByIdAsync/{bookId}");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var getResponse = await _client.GetAsync($"/api/Book/GetBookByIdAsync/{bookId}");
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [Fact]
        public async Task Delete_DeleteBook_ShouldReturnNotFoundResponse()
        {
            var bookId = new Guid("b3d5d0a0-9a3a-4e8e-8e1a-0b9e2b5f4f1a");
            var response = await _client.DeleteAsync($"/api/Book/DeleteBookByIdAsync/{bookId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
