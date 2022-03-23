using System.Text;

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
            var builder = new StringBuilder(Environment.NewLine);
            var headers = httpContext.Request.Headers.UserAgent;
            foreach (var header in headers)
            {
                builder.Append(header);
            }

            logger.LogInformation(message: builder.ToString());

            await this.next(httpContext);
        }
    }
}
