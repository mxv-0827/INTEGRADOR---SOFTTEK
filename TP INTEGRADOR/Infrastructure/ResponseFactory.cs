using Microsoft.AspNetCore.Mvc;

namespace TP_INTEGRADOR.Infrastructure
{
    public static class ResponseFactory
    {
        public static ActionResult CreateSuccessResponse(int statusCode, object? data)
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


        public static ObjectResult CreateErrorResponse(int statusCode, string errorMessage)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };

            return new ObjectResult(errorResponse)
            {
                StatusCode = statusCode,
            };
        }
    }
}
