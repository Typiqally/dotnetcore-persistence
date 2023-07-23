namespace NetCore.Persistence.Abstractions;

public interface IEntity<TKey> : IEntity
{
    public new TKey Id { get; set; }
}