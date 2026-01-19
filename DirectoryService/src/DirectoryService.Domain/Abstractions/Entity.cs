namespace DirectoryService.Domain.Abstractions;

public abstract class Entity : IEntity
{
    public Guid Id { get; init; }

    public required bool IsActive { get; init; }

    public required DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; private set; }

    public Entity(Guid id)
    {
        Id = id;
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
