using GraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace GraphQL;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("OrdersDb")));

        return builder;
    }
    
    public static WebApplication CreateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var context = scopedServices.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();

        return app;
    }
}