using System.Net;

namespace SpaceStation.Models
{
    public class BaseResponse
    {
        public bool IsErrorResponse { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
    }
}
