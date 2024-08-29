namespace SchemaFirst.Types;

public class Query
{
    public string SayHello(string name)
        => $"Hello {name}.";

    public Order GetOrder()
        => new Order("Order #1");
}

public record Order(string number);