namespace Library.RadenRovcanin.API.CustomMiddleware
{
    using System.Text;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    /// </summary>
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMiddleware"/> class.
        /// </summary>
        /// <param name="next">Next.</param>
        /// <param name="log">Logger.</param>
        public CustomMiddleware(RequestDelegate next, ILoggerFactory log)
        {
            this.next = next;
            this.logger = log.CreateLogger("Request header middleware");
        }

        /// <summary>
        /// action that happens when middleware is invoked.
        /// </summary>
        /// <param name="httpContext">http.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
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

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
