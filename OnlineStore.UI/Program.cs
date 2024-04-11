using OnlineStore.UI.Middleware;
using OnlineStore.UI.ServiceCollection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRepositoryWrapper();

var app = builder.Build();

app.UseCustomExceptionHandlerMiddleware();

app.MapGet("/", () => "Hello World!");

app.Run();
