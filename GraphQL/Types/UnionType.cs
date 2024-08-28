namespace GraphQL.Types;

[ExtendObjectType(nameof(GlobalQuery))]
public class GetUnionQuery
{
    public IEnumerable<ICreature> GetCatOrDog() => [new Cat("night"), new Dog("gachi")];
}

[UnionType]
public interface ICreature
{
    public string Name { get;}
}

public record Cat(string Name) : ICreature;
public record Dog(string Name): ICreature;