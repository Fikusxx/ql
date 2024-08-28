using GraphQL.Database;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.OrderTypes;

public sealed class ShopQuery
{
    public async Task<IEnumerable<Order>> GetOrders([Service] AppDbContext ctx) => await ctx.Orders
        .Include(x => x.Customer).ToListAsync();
    
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
}