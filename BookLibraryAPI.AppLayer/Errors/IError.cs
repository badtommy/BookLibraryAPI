using System.Net;

namespace BookLibraryAPI.AppLayer.Errors
{
    public interface IError
    {
        string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
