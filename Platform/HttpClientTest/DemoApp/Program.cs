using System.Net;

string item = args[0].ToLower();
int quantity = int.Parse(args[1]);
string url = $"http://iitdac.met.edu/shop/{item}";
var client = new HttpClient();
try
{
    client.DefaultRequestHeaders.Add("Accept", "text/plain");
    //string message = client.GetStringAsync(url).Result;
    string message = await client.GetStringAsync(url);
    var info = ItemInfo.Parse(message);
    if(quantity <= info.Stock)
        Console.WriteLine("Total Payment: {0:0.00}", 1.18 * quantity * info.Price);
    else    
        Console.WriteLine("Item out of stock!");
}
catch(HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
{
    Console.WriteLine("Item not sold!");
}
