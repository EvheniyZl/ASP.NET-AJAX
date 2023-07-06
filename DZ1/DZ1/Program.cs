using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    if (context.Request.Path == "/info") // Запит на певну інформацію " /info або такий info?name=ivan&age=33 "
        await context.Response.WriteAsync($"<p>Host: {context.Request.Host}</p>" + $"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>");
    else if (context.Request.Path == "/time") // Запит на час
    {
        var path = context.Request.Path;
        var now = DateTime.Now;
        var response = context.Response;
        response.Headers.ContentType = "text/plain; charset=utf-8";
        await response.WriteAsync($"Дата-Час: {now}");
    }
    else if (context.Request.Path == "/key") // Запит на ключ із файлу appsettings.json
    {
        IConfigurationSection pointSection = app.Configuration.GetSection("Logging:LogLevel");
        string y = pointSection["Default"];
        string z = pointSection["Microsoft.AspNetCore"];

        await context.Response.WriteAsync($"LogLevel: {y},{z};");
    }
    else // Пустий запит
    {
        var response = context.Response;
        response.Headers.ContentLanguage = "ua-UA";
        response.Headers.ContentType = "text/plain; charset=utf-8";
        await response.WriteAsync("Привіт користувач NET 6.0");
    }
});

app.Run();
