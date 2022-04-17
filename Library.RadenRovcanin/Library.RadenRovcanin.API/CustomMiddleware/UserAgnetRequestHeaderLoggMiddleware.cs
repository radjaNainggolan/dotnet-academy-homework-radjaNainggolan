using Microsoft.Extensions.Primitives;

namespace Library.RadenRovcanin.API.CustomMiddleware
{
    public class UserAgnetRequestHeaderLoggMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public UserAgnetRequestHeaderLoggMiddleware(RequestDelegate next, ILoggerFactory log)
        {
            this.next = next;
            this.logger = log.CreateLogger("Request header middleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StringValues headers = httpContext.Request.Headers.UserAgent;
            string message = $"Logging header {headers[0]}";
            logger.LogInformation(message: message);

            await this.next(httpContext);
        }
    }
}
