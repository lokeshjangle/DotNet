using DemoApp.Shared;
using Grpc.Core;
using Sales;
using OrderManagerStub = Sales.OrderManager.OrderManagerClient;

namespace DemoApp.Server;

public static class OrderManagerApi
{
    private static async Task<IResult> CreateOrder(Order resource, OrderManagerStub remote)
    {
        var request = new OrderInput 
        {
            CustomerCode = resource.CustomerId,
            ItemCode = resource.ProductNo,
            ItemCount = resource.Quantity
        };
        try
        {
            var reply = await remote.PlaceOrderAsync(request);
            resource.Id = reply.ConfirmationCode;
            return Results.Ok(resource);
        }
        catch(Exception)
        {
            //return Results.StatusCode(500);
            return Results.Problem(statusCode: 500, detail: "Order Failed");
        }
    }

    private static async Task<IResult> ReadOrders(string customerId, OrderManagerStub remote)
    {
        var request = new CustomerInput 
        {
            CustomerCode = customerId
        };
        using var reply = remote.FetchOrders(request);
        var orders = await reply.ResponseStream.ReadAllAsync()
                        .Select(entry => new Order
                        {
                            ProductNo = entry.ItemCode,
                            Quantity = entry.ItemCount,
                            OrderDate = entry.ConfirmationDate
                        })
                        .ToListAsync();
        return orders.Count > 0 ? Results.Ok(orders) : Results.NotFound();
    }

    public static void AddOrderManagerApi(this IServiceCollection services)
    {
        services.AddGrpcClient<OrderManagerStub>(channel => channel.Address = new Uri("http://localhost:4032"));
    }

    public static void MapOrderManagerApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/sales", CreateOrder);
        endpoints.MapGet("/api/sales/{customerId}", ReadOrders);
    }
}