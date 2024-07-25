using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class GlobalErrorMiddlewares(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message;
            string stackTrace = string.Empty;

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(ArgumentNullException) || exceptionType == typeof(ArgumentException))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = "Invalid argument provided.";
            }
            else if (exceptionType == typeof(InvalidOperationException))
            {
                statusCode = HttpStatusCode.Conflict;
                message = "Operation is not valid.";
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = "Access is denied.";
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                stackTrace = ex.StackTrace;
            }

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = message,
                Detailed = stackTrace
            };

            var responseJson = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(responseJson);
        }
    }
}
