using GraphQL.Models;
using HotChocolate.Data.Sorting;

namespace GraphQL.OrderTypes;

/// <summary>
/// defines on what fields consumer can sort
/// </summary>
public sealed class OrderSortInputType : SortInputType<Order>
{
    protected override void Configure(ISortInputTypeDescriptor<Order> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Number).Type<AscOnlySortEnumType>();
        // descriptor.Field(x => x.Customer).Type<CustomerSortInputType>();
        descriptor.Field(x => x.Customer);
    }
}

/// <summary>
/// works, cause it's 1-1 mapping with order
/// </summary>
public sealed class CustomerSortInputType : SortInputType<Customer>
{
    protected override void Configure(ISortInputTypeDescriptor<Customer> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Age);
    }
}

/// <summary>
/// allows to sort only in asc order
/// </summary>
public class AscOnlySortEnumType : DefaultSortEnumType
{
    protected override void Configure(ISortEnumTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultSortOperations.Ascending);
    }
}

/// <summary>
/// doesnt work cause its 1-many with order
/// </summary>
public sealed class LineItemSortInputType : SortInputType<LineItem>
{
    protected override void Configure(ISortInputTypeDescriptor<LineItem> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.ProductName);
    }
}