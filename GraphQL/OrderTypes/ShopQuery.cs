using GraphQL.Database;
using GraphQL.Models;
using GraphQL.OrderTypes.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.OrderTypes;

// [QueryType]
public sealed class ShopQuery
{
    [UseProjection]
    public async Task<IEnumerable<Order>> GetOrders(
        [Service] AppDbContext ctx,
        CancellationToken token
    ) => await ctx.Orders
        .Include(x => x.Customer).ToListAsync(token);

    /// <summary>
    /// [UseProjection] does selective select ... depending on graphql query instead of select * and then projecting
    /// [UsePaging] adds paging options to the query, overrides global paging options
    /// [UseFiltering] adds filtering options to Order model for every field by default, overriden in Filters
    /// [UseSorting] adds sorting options
    /// </summary>
    [UsePaging(DefaultPageSize = 3)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Order> GetOrdersWithProjection([Service] AppDbContext ctx) => ctx.Orders;

    public async Task<Order?> GetOrderById(int id, [Service] AppDbContext ctx, CancellationToken token) =>
        await ctx.Orders
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id, token);

    [Error<IMyErrorInterface>]
    public Order? GetOrderWithException(bool throwNative)
    {
        if (throwNative)
            throw new GraphQLException(ErrorBuilder.New()
                .SetMessage("Native ql exception")
                .Build());
        
        throw new TechnicalException();
    }
    
    public Order? GetOrderWithException2(bool throwNative)
    {
        if (throwNative)
            throw new GraphQLException(ErrorBuilder.New()
                .SetMessage("Native ql exception")
                .Build());
        
        throw new TechnicalException();
    }
}

public interface IMyErrorInterface
{
    public string Message { get; }
}