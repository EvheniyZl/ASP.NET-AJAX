using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//��������� ������ ���� ���� ���������� ����� ������ �� �볺��� � ���������� �������� �����:
//1.���� �볺�� ����� �� ������� � ���������� ������ ���� ��������� ��������� ������ ���������� NET 6.0�
//2.	���� ����� ���� ����� /info ��� ����� 
///info?name=ivan&age=33 ���� ��������� ���������� ���� ������ ������:
//Host = localhost:port
//Path = info
//QueryString = name=ivan&age=33
//3.	 ���� ����� ���� ����� /time  ���� ��������� ������� ���� �� ���.
//4.	���� ����� ���� ����� /key  ���� ��������� �������� ���������� ����� �� ����� appsettings.json.


app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    if (context.Request.Path == "/info") // ����� �� ����� ���������� " /info ��� ����� info?name=ivan&age=33 "
        await context.Response.WriteAsync($"<p>Host: {context.Request.Host}</p>" + $"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>");
    else if (context.Request.Path == "/time") // ����� �� ���
    {
        var path = context.Request.Path;
        var now = DateTime.Now;
        var response = context.Response;
        response.Headers.ContentType = "text/plain; charset=utf-8";
        await response.WriteAsync($"����-���: {now}");
    }
    else if (context.Request.Path == "/key") // ����� �� ���� �� ����� appsettings.json
    {
        IConfigurationSection pointSection = app.Configuration.GetSection("Logging:LogLevel");
        string y = pointSection["Default"];
        string z = pointSection["Microsoft.AspNetCore"];

        await context.Response.WriteAsync($"LogLevel: {y},{z};");
    }
    else // ������ �����
    {
        var response = context.Response;
        response.Headers.ContentLanguage = "ua-UA";
        response.Headers.ContentType = "text/plain; charset=utf-8";
        await response.WriteAsync("����� ���������� NET 6.0");
    }
});

app.Run();
