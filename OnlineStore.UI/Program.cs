using OnlineStore.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseCustomExceptionHandlerMiddleware();


app.Run();
