using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class GlobalErrorMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly IWebHostEnvironment _env = env;

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

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message;
            string stackTrace = _env.IsDevelopment() ? ex.StackTrace : null;

            if (ex is KeyNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = ex.Message ?? "The requested resource was not found.";
            }
            else if (ex is ArgumentNullException || ex is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = "Invalid argument provided.";
            }
            else if (ex is InvalidOperationException)
            {
                statusCode = HttpStatusCode.Conflict;
                message = "Operation is not valid.";
            }
            else if (ex is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = "Access is denied.";
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
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
