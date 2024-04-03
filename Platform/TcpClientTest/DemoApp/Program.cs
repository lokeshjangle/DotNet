using System.Net.Sockets;

string item = args[0].ToLower();
int quantity = int.Parse(args[1]);
//Step 1
using var connection = new TcpClient(args[2], 4000);
//Step 2
var remote = connection.GetStream();
using var reader = new StreamReader(remote);
using var writer = new StreamWriter(remote);
Console.WriteLine(reader.ReadLine());
writer.WriteLine(item);
writer.Flush();
string message = reader.ReadLine();
if(message != null)
{
    var info = ItemInfo.Parse(message);
    if(quantity <= info.Stock)
        Console.WriteLine("Total Payment: {0:0.00}", 1.18 * quantity * info.Price);
    else
        Console.WriteLine("Item out of stock!");
}
else
{
    Console.WriteLine("Item not sold!");
}
//Step 3 (connection will be closed by Dispose)
