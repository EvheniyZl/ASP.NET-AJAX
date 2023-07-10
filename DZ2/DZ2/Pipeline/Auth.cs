namespace PipelineCustomMiddleware.PipelineMiddleware
{
    public class CustomAuthenticationMiddleware
    {
        private RequestDelegate _next;
        private string _passwd;
        private string _login;


        public CustomAuthenticationMiddleware(RequestDelegate next, string login, string passwd)
        {
            _next = next;
            _login = login;
            _passwd = passwd;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"];
            var passwd = context.Request.Query["passwd"];
            if (string.IsNullOrWhiteSpace(login) || login != _login || string.IsNullOrWhiteSpace(passwd) || passwd != _passwd)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
