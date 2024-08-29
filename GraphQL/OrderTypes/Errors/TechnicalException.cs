namespace GraphQL.OrderTypes.Errors;

public class TechnicalException : Exception
{
    public string GetErrorInfo() => "Oops.. Something bad happen :(";
}