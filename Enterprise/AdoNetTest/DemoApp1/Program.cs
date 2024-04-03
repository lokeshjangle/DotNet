using var connection = new Microsoft.Data.Sqlite.SqliteConnection("Data Source=shop.db");
connection.Open();
using var command = connection.CreateCommand();
if(args.Length == 0)
{
    command.CommandText = "SELECT UserName, Credit, Address FROM CustomerInfo";
    using var reader = command.ExecuteReader();
    while(reader.Read())
        Console.WriteLine("{0}\t{1:0.00}\t{2}", reader.GetString(0), reader.GetDouble(1), reader.GetString(2));
}
else if(args[0].Length == 5)
{
    command.CommandText = $"UPDATE CustomerInfo SET Credit=Credit+250 WHERE UserName='{args[0]}'";
    int n = command.ExecuteNonQuery();
    if(n > 0)
        Console.WriteLine("Customer credit incremented.");
    else
        Console.WriteLine("No such customer!");
}