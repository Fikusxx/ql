namespace GraphQL.Types;

[ExtendObjectType(nameof(GlobalQuery))]
public class GetOneOfTypeQuery
{
    public string GetCatOrDogName(CatOrDog catOrDog) =>
        catOrDog.cat?.Name ?? catOrDog.dog!.Name;
}

[OneOf]
public record CatOrDog(Cat? cat, Dog? dog);