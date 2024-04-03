using DemoApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddAuthentication()
    .AddCookie(option => option.LoginPath = "/Index");
builder.Services.AddDbContext<ShopDbContext>(
    options => options.UseSqlServer("Data Source=iitdac.met.edu;Database=Shop1;User ID=dac1;Password=Dac1@1234;Encrypt=False"));
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
