using NetCore.Persistence.Abstractions;

namespace NetCore.Persistence.Memory;

public class MemoryBasedRepositoryOptions<TEntity> : RepositoryOptions
    where TEntity : class, IEntity
{
    public IDictionary<object, TEntity> Data { get; set; }
}