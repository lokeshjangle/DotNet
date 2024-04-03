namespace DemoApp;

static class Handlers
{
    public static async Task Greet(HttpResponse response, string guest = "Visitor")
    {
        await response.WriteAsync(
        $""""
        <html>
            <head>
                <title>DemoApp</title>
            </head>
            <body>
                <h1>Welcome {guest}</h1>
                <b>Current Time: </b>{DateTime.Now.ToString("HH:mm:ss yyyy-MM-dd")}
            </body>
        </html>
        """"
        );
    }

}