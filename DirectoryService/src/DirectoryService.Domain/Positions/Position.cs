using DirectoryService.Domain.Abstractions;

namespace DirectoryService.Domain.Positions;

public class Position: Entity
{
    public required PositionName Name { get; init; }

    public string? Description { get; private set; }

    public List<Guid> DepartmenPositiontIds { get; private set; } = [];

    public Position(Guid id, PositionName name, string? description = default)
        : base(id)
    {
        Name = name;
        Description = description;
    }
}
