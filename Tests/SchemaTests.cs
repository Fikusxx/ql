using CookieCrumble;
using GraphQL.OrderTypes;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

/// <summary>
/// should be part of CI pipeline
/// </summary>
public class SchemaTests
{
    [Fact]
    public async Task SchemaChanged()
    {
        var schema = await new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<ShopQuery>()
            .AddType<OrderFilterInputType>()
            .AddType<OrderSortInputType>()
            .ModifyPagingOptions(opt =>
            {
                opt.DefaultPageSize = 2;
                opt.MaxPageSize = 123;
                opt.AllowBackwardPagination = false;
            })
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            // if there are some errors regarding di container, this project has none tho
            // this basically says that "dw, its gonna be there"
            // or just use extensions for registering App/Infra services from specific projects.
            .AddParameterExpressionBuilder<HttpContext>(ctx => default!)
            .AddMutationConventions()
            .BuildSchemaAsync();
        
        schema.MatchSnapshot();
    }
}