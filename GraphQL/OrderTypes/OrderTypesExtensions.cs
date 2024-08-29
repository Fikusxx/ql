using System.Net;
using GraphQL.OrderTypes.Errors;
using HotChocolate.Types.Pagination;

namespace GraphQL.OrderTypes;

public static class OrderTypesExtensions
{
    // ReSharper disable once InconsistentNaming
    public static WebApplicationBuilder AddOrdersGraphQL(this WebApplicationBuilder builder)
    {
        builder.Services.AddGraphQLServer()
            // source generators work like shit, no use, need attributes everywhere
            // .AddGraphQLTypes() 
            .AddQueryType<ShopQuery>()
            .AddType<OrderFilterInputType>() // custom filter type
            .AddType<OrderSortInputType>() // custom sort type
            .AddType<CustomStringOperationFilterInputType>()
            .AddType<CustomerSortInputType>()
            
            // global paging options
            .ModifyPagingOptions(options =>
            {
                options.DefaultPageSize = 2;
                options.MaxPageSize = 123; // makes no sense lol
                options.AllowBackwardPagination = false; // cant go from end to start
            })
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .AddErrorFilter(error =>
            {
                if (error.Exception is not TechnicalException e) 
                    return error;
                
                var errorBuilder = ErrorBuilder.FromError(error)
                    .ClearExtensions(); // clears stack trace
                errorBuilder.SetMessage("This is top level message");
                errorBuilder.SetExtension("type", e.GetType().Name);
                errorBuilder.SetExtension("message", e.GetErrorInfo());
                errorBuilder.SetCode(HttpStatusCode.BadRequest.ToString());
                return errorBuilder.Build();
            })
            // .AddGlobalObjectIdentification()
            .AddMutationConventions()
            // .AddErrorInterfaceType<IMyErrorInterface>()
            .InitializeOnStartup();

        return builder;
    }
}