using System.Net;

namespace Sudoku.Models.Entities
{
    public class RequestResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public string? StatusMessage { get; set; }   

        public T? Response { get; set; }

        public string? ErrorMessage { get; set; }

        public RequestResponse(HttpStatusCode httpStatusCode, string statusMessage, string errorMessage, T response)
        {
            StatusCode = httpStatusCode; StatusMessage = statusMessage; ErrorMessage = errorMessage; Response = response;
        }
    }
}
