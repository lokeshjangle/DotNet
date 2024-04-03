using System.Data;

int productNo = int.Parse(args[0]);
int quantity = int.Parse(args[1]);
string customerId = args[2].ToUpper();
using var connection = new Microsoft.Data.SqlClient.SqlConnection();
connection.ConnectionString = "Data Source=iitdac.met.edu;Database=Shop1;User ID=dac1;Password=Dac1@1234;Encrypt=False";
connection.Open();
using var command = connection.CreateCommand();
command.Transaction = connection.BeginTransaction();
try
{
    command.CommandText = "UPDATE ProductInfo SET Stock=Stock-@Quantity WHERE ProductNo=@Product";
    command.Parameters.AddWithValue("@Product", productNo);
    command.Parameters.AddWithValue("@Quantity", quantity);
    command.ExecuteNonQuery();
    command.CommandText = "PlaceOrder";
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.AddWithValue("@Customer", customerId);
    var orderIdParam = command.Parameters.Add("@OrderId", SqlDbType.Int);
    orderIdParam.Direction = ParameterDirection.Output;
    decimal payment = (decimal)command.ExecuteScalar();
    command.Transaction.Commit();
    Console.WriteLine("New Order Number is {0} and Payment is {1:0.00}", orderIdParam.Value, payment);
}
catch(Exception ex)
{
    command.Transaction.Rollback();
    Console.WriteLine("Order Failed: {0}", ex.Message);
}
