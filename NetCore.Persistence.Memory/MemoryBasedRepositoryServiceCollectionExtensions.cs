using Microsoft.Extensions.DependencyInjection;
using NetCore.Persistence.Abstractions;

namespace NetCore.Persistence.Memory;

public static class MemoryBasedRepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddMemoryBasedRepository<TEntity>(this IServiceCollection services, Action<MemoryBasedRepositoryOptions<TEntity>>? configureOptions = null)
        where TEntity : class, IEntity
    {
        var options = new MemoryBasedRepositoryOptions<TEntity>();
        configureOptions?.Invoke(options);

        if (options.ReadOnly)
        {
            services.AddSingleton<IReadOnlyRepository<TEntity>, MemoryBasedReadOnlyRepository<TEntity>>(_ => new MemoryBasedReadOnlyRepository<TEntity>(options.Data));
        }
        else
        {
            services.AddSingleton<IRepository<TEntity>, MemoryBasedRepository<TEntity>>(_ => new MemoryBasedRepository<TEntity>(options.Data));
        }

        return services;
    }
}