namespace GraphQL.Models;

public sealed class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public required string Number { get; set; }
    public List<LineItem> Items { get; set; }
}