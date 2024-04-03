var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc(); //enable gRPC
var app = builder.Build();
app.MapGrpcService<DemoApp.Shopping.OrderManagerService>();
//Enable HTTP/2 for Kestrel (see appsettings.json)
//which is required by gRPC
app.Run("http://localhost:4032");

