

using HttpProtocolClient.Models;
using System.Text.Json;

using var client = new HttpClient();

var url = "https://localhost:7044/api/Orders";

var response1 = await client.GetAsync(url);

var content = await response1.Content.ReadAsStringAsync();

foreach (var header in response1.Headers)
{
    Console.WriteLine($"Key:{header.Key} - Value:{string.Join(",", header.Value)}");
}

Console.WriteLine(response1.StatusCode);

var orders = JsonSerializer.Deserialize<List<Order>>(content, new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true
});

foreach (var order in orders)
{
    Console.WriteLine($"Id: {order.Id} - Name:{order.Name} - Description:{order.Description}");
}



