using System.Text.Json;

namespace PipelineCustomMiddleware.PipelineMiddleware
{
    public class CustomRoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string path = context.Request.Path.Value != null ? context.Request.Path.Value.ToLower() : "";

            switch (path)
            {
                case "/home":
                    await context.Response.WriteAsync("<h1>Домашня сторінка</h1>");
                    break;

                case "/mypicture":
                    await context.Response.WriteAsync("<img src = 'https://static.javatpoint.com/asp/images/asp-net-tutorial.png'>");
                    break;

                case "/mycredential":
                    string login = context.Request.Query["login"];
                    string passwd = context.Request.Query["passwd"];
                    await context.Response.WriteAsync($"Login: {login}, Password: {passwd}");
                    break;

                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }
}