namespace Core.Database.Models;

// Base Interface for all entities
public interface IEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}

public interface IEntity<TKey> : IEntity where TKey : IComparable, IEquatable<TKey>
{
    TKey Id { get; set; }
}
