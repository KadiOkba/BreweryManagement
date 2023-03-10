using BreweryManagement.Application.Exceptions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationException = BreweryManagement.Application.Exceptions.ValidationException;

namespace BreweryManagement.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            object result = null!;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = new { error = JsonConvert.SerializeObject(validationException.Failures) };
                    break;
                case NotValidException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = new { error = badRequestException.Message };
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = new { error = notFoundException.Message };
                    break;
                case AlreadyExistsExeption alreadyExistsExeption:
                    code = HttpStatusCode.Conflict;
                    result = new { error = alreadyExistsExeption.Message };
                    break;
                case UnauthorizedAccessException unauthorized:
                    code = HttpStatusCode.Unauthorized;
                    result = new { error = unauthorized.Message };
                    break;
                default:
                    break;
            }

            logger.LogError(exception.ToString());

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
            if (result == null)
            {
                result = new { error = exception.Message };
            }
            context.Response.Headers.Clear();
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
