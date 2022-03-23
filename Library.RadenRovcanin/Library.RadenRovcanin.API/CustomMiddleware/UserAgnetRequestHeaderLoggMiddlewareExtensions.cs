namespace Library.RadenRovcanin.API.CustomMiddleware
{
    public static class UserAgnetRequestHeaderLoggMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAgnetRequestHeaderLoggMiddleware>();
        }
    }
}
