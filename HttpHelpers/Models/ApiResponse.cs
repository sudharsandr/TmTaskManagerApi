using System.Net;

namespace TmTaskManagerApi.HttpHelpers.Models
{
    public class ApiResponse<T>
    {
        public T? Response { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
