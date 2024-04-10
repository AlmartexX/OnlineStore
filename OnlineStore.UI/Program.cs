using OnlineStore.UI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCustomExceptionHandlerMiddleware();

app.MapGet("/", () => "Hello World!");

app.Run();
