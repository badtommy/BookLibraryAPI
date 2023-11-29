using System.Net;

namespace BookLibraryAPI.AppLayer.Errors
{
    public class Error : IError
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
