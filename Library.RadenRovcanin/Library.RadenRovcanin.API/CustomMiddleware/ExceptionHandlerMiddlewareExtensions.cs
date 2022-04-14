namespace Library.RadenRovcanin.API.CustomMiddleware
{

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExcpetionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExcpetionHandlerMiddleware>();
        }
    }
}
