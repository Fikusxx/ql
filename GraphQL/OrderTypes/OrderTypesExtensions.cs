using HotChocolate.Types.Pagination;

namespace GraphQL.OrderTypes;

public static class OrderTypesExtensions
{
    // ReSharper disable once InconsistentNaming
    public static WebApplicationBuilder AddOrdersGraphQL(this WebApplicationBuilder builder)
    {
        builder.Services.AddGraphQLServer()
            .AddQueryType<ShopQuery>()
            .AddType<OrderFilterInputType>() // custom filter type
            .AddType<OrderSortInputType>() // custom sort type
            
            // global paging options
            .SetPagingOptions(new PagingOptions()
            {
                DefaultPageSize = 2,
                MaxPageSize = 123, // makes no sense lol
                AllowBackwardPagination = false, // cant go from end to start
            })
            .AddProjections()
            .AddFiltering()
            .AddSorting();

        return builder;
    }
}