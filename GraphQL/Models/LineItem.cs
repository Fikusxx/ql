

namespace GraphQL.Models;

public sealed class LineItem
{
    public required string ProductName { get; set; }
    public int Amount { get; set; }
}