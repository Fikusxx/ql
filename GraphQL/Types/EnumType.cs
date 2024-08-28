namespace GraphQL.Types;

[ExtendObjectType(nameof(GlobalQuery))]
public class GetEnumQuery
{
    public Creature GetCreature() => new Creature("gachi", Pet.Dog);
}

public record Creature(string name, Pet Pet);

[EnumType]
public enum Pet
{
    Cat,
    Dog
}