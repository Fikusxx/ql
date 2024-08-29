namespace GraphQL.OrderTypes.Errors;

public class DomainException : Exception, IMyErrorInterface
{
    public string GetErrorInfo() => "This is a domain error... Like not found or smth";
}