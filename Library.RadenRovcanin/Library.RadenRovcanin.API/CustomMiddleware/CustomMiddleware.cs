namespace Library.RadenRovcanin.API.CustomMiddleware
{
    using System.Text;
    using Microsoft.Extensions.Logging;

    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory log)
        {
            this.next = next;
            this.logger = log.CreateLogger("Request header middleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var builder = new StringBuilder(Environment.NewLine);
            foreach (var header in httpContext.Request.Headers)
            {
                builder.AppendLine($"{header.Key} : {header.Value}");
            }

            this.logger.LogInformation(builder.ToString());

            await this.next(httpContext);
        }
    }
}
