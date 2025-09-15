namespace Core.Database.Models;

// Base class all entities interit from
public abstract class EntityBase<TKey> : IEntity<TKey> where TKey : IComparable, IEquatable<TKey>
{
    // Implements the interface
    public TKey Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}