namespace DirectoryService.Domain.Abstractions;

public interface IEntity
{
    Guid Id { get; init; }

    bool IsActive { get; init; }

    DateTime CreatedAt { get; init; }

    DateTime UpdatedAt { get; }
}