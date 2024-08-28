using GraphQL.Models;
using HotChocolate.Data.Filters;

namespace GraphQL.OrderTypes;

/// <summary>
/// defines on what fields consumer can filter
/// </summary>
public sealed class OrderFilterInputType : FilterInputType<Order>
{
    protected override void Configure(IFilterInputTypeDescriptor<Order> descriptor)
    {
        // filtering are allowed only on these fields
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Number).Type<CustomStringOperationFilterInputType>();
        descriptor.Field(x => x.Id);
    }
}

/// <summary>
/// defines what operation with specific field types consumer can do
/// </summary>
public sealed class CustomStringOperationFilterInputType : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.Contains).Type<StringType>();
    }
}