using System.Net.Http.Json;
using DemoApp.Shared;
using Microsoft.AspNetCore.Components;

namespace DemoApp.Client.Pages;

partial class Index
{
    [Inject]
    public HttpClient Backend { get; set; }

    public Order Input { get; set; } = new();

    public List<Order> Invoice { get; set; }

    public string StatusMessage { get; set; }

    public async Task GetOrders()
    {
        Invoice = null;
        try
        {
            Invoice = await Backend.GetFromJsonAsync<List<Order>>($"/api/sales/{Input.CustomerId}");
            StatusMessage = "";
        }
        catch(HttpRequestException)
        {
            StatusMessage = "Cannot fetch orders!";
        }
    }

    public async Task PostOrder()
    {
        Invoice = null;
        var response = await Backend.PostAsJsonAsync("/api/sales", Input);
        if(response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Order>();
            StatusMessage = $"New order number is {result.Id}";
        }
        else
        {
            StatusMessage = "Cannot place order!";
        }
    }
}