using System.Net;
using System.Text.Json;
using Library.RadenRovcanin.Contracts;
using Library.RadenRovcanin.Contracts.Exceptions;

namespace Library.RadenRovcanin.API.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExcpetionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExcpetionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await OnExcpetion(httpContext, ex);
            }
        }

        public async Task OnExcpetion(HttpContext httpContext, Exception ex)
        {
            object response;
            _ = ex switch
            {
                BookNotAvaliableException => httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound,

                EntityNotFoundException => httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound,

                EntityAlreadyExistsException => httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict,

                UserAuthenticationException => httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized,

                BookRentingException => httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound,

                UserRegistrationException => httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest,

                _ => httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError,
            };

            response = new
            {
                ex.Message,
            };

            httpContext.Response.ContentType = "application/json";

            var resultJson = JsonSerializer.Serialize(response);

            await httpContext.Response.WriteAsync(resultJson);
        }
    }
}
