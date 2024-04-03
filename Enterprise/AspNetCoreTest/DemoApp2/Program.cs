using DemoApp.Services;

var builder = WebApplication.CreateBuilder(args);
//add services
//builder.Services.AddSingleton<ICounter, CommonCounter>();
builder.Services.AddTransient<ICounter, NamedCounter>();
var app = builder.Build();
//use middlewares
app.UseFileServer(); //will serve static files from ~/wwwroot
//map handlers
app.MapPost("/Welcome", DemoApp.Handlers.Greet);
app.Run();
