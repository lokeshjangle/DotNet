var builder = WebApplication.CreateBuilder(args);
//add services
var app = builder.Build();
//use middlewares
app.UseFileServer(); //will serve static files from ~/wwwroot
app.UseMiddleware<DemoApp.Middlewares.Pausing>();
//map handlers
app.MapGet("/Welcome", DemoApp.Handlers.Greet);
app.Run();