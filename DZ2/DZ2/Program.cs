using PipelineCustomMiddleware.PipelineMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
            .AddJsonFile("login.json",
                         optional: true)
            .AddJsonFile("appsettings.json",
                         optional: true,
                         reloadOnChange: true);

var app = builder.Build();

// /home?login=Evgeniy&passwd=4321
// /mypicture?login=Evgeniy&passwd=4321
// /mycredential?login=Evgeniy&passwd=4321

string login = app.Configuration["Login"];
string passwd = app.Configuration["passwd"];

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseErrorHandling();

app.UseCustomAuthentication(login, passwd);

app.UseCustomRouting();

app.Run();
