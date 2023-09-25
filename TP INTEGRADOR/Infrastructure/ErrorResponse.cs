using System.Text.Json.Serialization;

namespace TP_INTEGRADOR.Infrastructure
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
