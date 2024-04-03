using DemoApp.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOrderManagerApi();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapFallbackToFile("index.html");
app.MapOrderManagerApi();
app.Run();
