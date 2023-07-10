namespace PipelineCustomMiddleware.PipelineMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app, string login, string passwd)
        {
            return app.UseMiddleware<CustomAuthenticationMiddleware>(login, passwd);
        }

        public static IApplicationBuilder UseCustomRouting(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomRoutingMiddleware>();
        }
    }
}
