using DemoApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //enable razor pages
builder.Services.AddSingleton<ICounter, CommonCounter>();
var app = builder.Build();
//map the handler of ~/Pages/X.cshtml to path specified by
//the @page directive in X.cshtml otherwise to path /X with
//X=Index by default 
app.MapRazorPages();
app.Run();
