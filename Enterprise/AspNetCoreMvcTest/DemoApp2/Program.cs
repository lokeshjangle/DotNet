var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DemoApp.Models.SiteDbContext>();
var app = builder.Build();
app.UseFileServer();
//allow file-server to execute before routing
app.UseRouting();
//web-browser only permits the code running within its context to
//consume resources from the endpoint from which that code originated
//(same origin policy) or from an endpoint which has enabled 
//cross origin resource sharing (CORS) policy
app.UseCors(permissions => permissions.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapDefaultControllerRoute();
app.Run();
