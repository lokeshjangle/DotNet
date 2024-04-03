namespace DemoApp.Middlewares;

public class Pausing
{
    private readonly RequestDelegate _next;
    private DateTime recent;

    public Pausing(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var current = DateTime.Now;
        if(current - recent > TimeSpan.FromSeconds(3))
        {
            await _next.Invoke(context);
            recent = current;
        }
        else
        {
            await context.Response.WriteAsync("Server is busy, try after some time...");
        }
    }
}