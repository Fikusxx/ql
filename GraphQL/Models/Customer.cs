namespace GraphQL.Models;

public sealed class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
}