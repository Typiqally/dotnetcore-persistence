using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tpcly.Persistence.Abstractions;

namespace Tpcly.Persistence;

public abstract record Entity<TKey> : IEntity<TKey>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }

    object IEntity.Id
    {
        get => Id!;
        init => Id = value is TKey key ? key : throw new NullReferenceException("Entity key (id) should not be null");
    }
}