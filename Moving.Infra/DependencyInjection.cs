using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moving.Core.Repository.Abstractions;
using Moving.Core.Services.Abstractions;
using Moving.Infra.Context;
using Moving.Infra.Repository;
using Moving.Infra.Services;

namespace Moving.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }

    public static IServiceCollection AddContexts(this IServiceCollection services, string contentRootPath)
    {
        var databasePath = SqliteDatabasePath.FromContentRoot(contentRootPath);

        services.AddDbContext<SqliteContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
        });

        return services;
    }
}
