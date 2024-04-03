using Grpc.Core;
using Sales;

namespace DemoApp.Shopping;

public class OrderManagerService : OrderManager.OrderManagerBase
{
    public override async Task<OrderStatus> PlaceOrder(OrderInput request, ServerCallContext context)
    {
        var reply = new OrderStatus();
        var db = new ShopDbContext();
        var ctr = await db.Counters.FindAsync("order");
        var order = new Order 
        {
            Id = ++ctr.CurrentValue + ctr.SeedValue,
            OrderDate = DateTime.Today,
            CustomerId = request.CustomerCode,
            ProductNo = request.ItemCode,
            Quantity = request.ItemCount
        };
        db.Orders.Add(order);
        try
        {
            await db.SaveChangesAsync();
            reply.ConfirmationCode = order.Id;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            context.Status = new Status(StatusCode.Internal, "Order Failed");
        }
        return reply;
    }

    public override async Task FetchOrders(CustomerInput request, IServerStreamWriter<CustomerOrder> responseStream, ServerCallContext context)
    {
        var db = new ShopDbContext();
        var selection = from order in db.Orders
                        where order.CustomerId == request.CustomerCode
                        select new CustomerOrder 
                        {
                            ItemCode = order.ProductNo,
                            ItemCount = order.Quantity,
                            ConfirmationDate = order.OrderDate.ToString("yyyy-MM-dd")
                        };
        foreach(var entry in selection)
            await responseStream.WriteAsync(entry);
    }
}
