using GraphQL;
using GraphQL.Database;
using GraphQL.Models;
using GraphQL.OrderTypes;
using Microsoft.AspNetCore.Mvc;
using Customer = GraphQL.Models.Customer;
using Order = GraphQL.Models.Order;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer();
// builder.AddDefaultTypes();
builder.AddOrdersGraphQL();


builder.AddDatabase();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// default path - graphql
app.MapGraphQL();

app.CreateDb();

app.MapGet("/seed", async ([FromServices] AppDbContext ctx) =>
{
    await ctx.Customers.AddRangeAsync([
        new Customer { Id = 1, Name = "Tom", Age = 25 },
        new Customer { Id = 2, Name = "Alice", Age = 25 },
        new Customer { Id = 3, Name = "Bob", Age = 25 },
    ]);

    await ctx.SaveChangesAsync();
    
   await ctx.Orders.AddRangeAsync([
           new Order { Id = 1, Number = "#1", CustomerId = 1, Items = [
               new LineItem { ProductName = "Whopper", Amount = 2 },
               new LineItem { ProductName = "Angus", Amount = 3 }
           ]},
           new Order { Id = 2, Number = "#2", CustomerId = 1, Items = [
               new LineItem {  ProductName = "French Fries", Amount = 5 },
               new LineItem { ProductName = "Cola", Amount = 1 },
           ]},
           new Order { Id = 3, Number = "#3", CustomerId = 2, Items = [
               new LineItem { ProductName = "Cheeseburger", Amount = 13 },
               new LineItem { ProductName = "Gravy", Amount = 1 },
               new LineItem { ProductName = "Sprite", Amount = 1 }
           ]},
           new Order { Id = 4, Number = "#4", CustomerId = 3, Items = [
               new LineItem { ProductName = "Angus", Amount = 6 },
               new LineItem { ProductName = "Dr Pepper", Amount = 1 }
           ]},
           new Order { Id = 5, Number = "#5", CustomerId = 3, Items = [
               new LineItem { ProductName = "Large French Fries", Amount = 1 },
               new LineItem { ProductName = "Double Whopper", Amount = 2 },
               new LineItem { ProductName = "Tea", Amount = 1 },
               new LineItem { ProductName = "Cheese Sauce", Amount = 1 },
           ]},
       ]);

       await ctx.SaveChangesAsync();
    
    return Results.Ok();
});

app.Run();