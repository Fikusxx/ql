namespace GraphQL.Types;

public static class TypesExtensions
{
    public static void AddDefaultTypes(this WebApplicationBuilder builder)
    {
        builder.Services.AddGraphQLServer()
            .AddQueryType<GlobalQuery>()

            #region Object

            .AddTypeExtension<GetObjectQuery>()
            .AddTypeExtension(typeof(OrderExtensions))

            #endregion

            #region Interface

            .AddTypeExtension<GetInterfaceQuery>()
            .AddInterfaceType<IHasName>()
            .AddType<Me>()
            .AddType<Pug>()

            #endregion

            #region Union

            .AddTypeExtension<GetUnionQuery>()
            .AddUnionType<ICreature>()
            .AddType<Cat>()
            .AddType<Dog>()

            #endregion

            #region Enum

            .AddTypeExtension<GetEnumQuery>()
            .AddEnumType<Pet>()
            .AddType<Creature>()

            #endregion

            #region OneOf

            .AddTypeExtension<GetOneOfTypeQuery>()
            .ModifyOptions(opt => opt.EnableOneOf = true)

            #endregion

            ;
    }
}