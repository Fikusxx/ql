namespace GraphQL.Types;


/// <summary>
/// Get prefix for methods is omitted for some reason
/// </summary>
[ExtendObjectType(nameof(GlobalQuery))]
public sealed class GetObjectQuery
{
    // name - order
    public Order GetOrder() => new Order(number: "#1", new Customer(name: "Tom"));
    // name - orderById
    public Order GetOrderById() => new Order(number: "#1", new Customer(name: "Tom"));
}

public record Order(string number, Customer customer)
{
    public string Display() => $"Customer {customer.name} has placed an order with number {number}";
}
public record Customer(string name);

[ExtendObjectType<Order>]
public static class OrderExtensions
{
    public static string DisplayOuter([Parent] Order order)
    {
        return $"{order.customer.name} has placed an order with number {order.number}";
    }
}