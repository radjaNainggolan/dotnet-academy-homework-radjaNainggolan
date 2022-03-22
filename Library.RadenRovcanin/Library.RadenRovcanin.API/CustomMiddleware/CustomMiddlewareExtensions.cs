namespace Library.RadenRovcanin.API.CustomMiddleware
{
    using System.Text;
    using Microsoft.Extensions.Logging;

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
