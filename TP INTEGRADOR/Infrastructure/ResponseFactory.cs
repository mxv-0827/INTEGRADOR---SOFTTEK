using Microsoft.AspNetCore.Mvc;

namespace TP_INTEGRADOR.Infrastructure
{
    public static class ResponseFactory
    {
        public static IActionResult CreateSuccessResponse(int statusCode, object? data)
        {
            var response = new SuccessResponse
            {
                StatusCode = statusCode,
                Data = data
            };

            return new ObjectResult(response) 
            {
                StatusCode = statusCode,
            };
        }

        public static IActionResult CreateErrorResponse(int statusCode, string[] errors)
        {
            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Errors = new List<ErrorResponse.Error>()
            };

            foreach(string error in errors)
            {
                response.Errors.Add(new ErrorResponse.Error { Description = error });
            }

            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
    }
}
