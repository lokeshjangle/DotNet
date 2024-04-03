using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        var store = XElement.Load("CitiTek.xml")
                        .Elements("item")
                        .ToDictionary(i => i.Attribute("id").Value, i => i.Value);
        //Step 1
        var listener = new TcpListener(IPAddress.Any, 4000);
        listener.Start();
        Service(listener, store);
    }

    private static void Service(TcpListener listener, Dictionary<string, string> store)
    {
        do
        {
            //Step 2
            using var connection = listener.AcceptTcpClient();
            connection.ReceiveTimeout = 20000;
            var remote = connection.GetStream();
            using var reader = new StreamReader(remote);
            using var writer = new StreamWriter(remote) { AutoFlush = true };
            try
            {
                writer.WriteLine("Welcome to CitiTek Computers.");
                string item = reader.ReadLine();
                if(store.TryGetValue(item, out string info))
                    writer.WriteLine(info);
            }
            catch {}
            //Step 3
        }
        while(true);
    }
}
