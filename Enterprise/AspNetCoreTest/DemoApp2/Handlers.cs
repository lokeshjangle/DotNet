using DemoApp.Services;

namespace DemoApp;

static class Handlers
{
    public static async Task Greet(HttpResponse response, HttpRequest request, ICounter ctr)
    {
        string guest = request.Form["user"];
        if(guest.Length == 0)
        {
            response.Redirect("index.html?noname=true");
            return;
        }
        await response.WriteAsync(
        $""""
        <html>
            <head>
                <title>DemoApp</title>
            </head>
            <body>
                <h1>Welcome {guest}</h1>
                <b>Number of Greetings: </b>{ctr.CountNext(guest)}
            </body>
        </html>
        """"
        );
    }

}