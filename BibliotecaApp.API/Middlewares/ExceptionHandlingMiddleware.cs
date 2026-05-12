using BibliotecaApp.API.DTOs.Errors;
using BibliotecaApp.Application.Exceptions;

namespace BibliotecaApp.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException exception)
            {
                await WriteErrorResponseAsync(
                    context,
                    exception.StatusCode,
                    exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception");

                await WriteErrorResponseAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred. Please try again later.");
            }
        }

        private static async Task WriteErrorResponseAsync(
            HttpContext context,
            int statusCode,
            string message)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse(
                statusCode,
                message,
                context.Request.Path
            );

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
