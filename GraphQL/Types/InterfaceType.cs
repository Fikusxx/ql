namespace GraphQL.Types;


[ExtendObjectType(nameof(GlobalQuery))]
public class GetInterfaceQuery
{
    public IEnumerable<IHasName> GetMeOrPug() => [new Me(), new Pug()];
}


[InterfaceType]
public interface IHasName
{
    public string Name { get; set; }
}

public class Me : IHasName
{
    public string Name { get; set; } = "Fikus";
    public int Age { get; set; } = 25;
}

public class Pug : IHasName
{
    public string Name { get; set; } = "Gachi";
    public string Breed { get; set; } = nameof(Pug);
}