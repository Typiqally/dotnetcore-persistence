using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Persistence.Abstractions;

namespace NetCore.Persistence.EntityFrameworkCore;

public static class EntityFrameworkRepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkRepository<TContext, TEntity>(this IServiceCollection services, Action<RepositoryOptions>? configureOptions = null)
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        var options = new RepositoryOptions();
        configureOptions?.Invoke(options);

        if (options.ReadOnly)
        {
            services.AddScoped<IReadOnlyRepository<TEntity>, EntityFrameworkReadOnlyRepository<TContext, TEntity>>();
        }
        else
        {
            services.AddScoped<IRepository<TEntity>, EntityFrameworkRepository<TContext, TEntity>>();
        }

        return services;
    }
}