using DirectoryService.Domain.Abstractions;

namespace DirectoryService.Domain.Departments;

public class Department: Entity
{
    public required DepartmentName Name { get; init; }

    public required string Identifier { get; init; }

    public Guid? ParentId { get; private set; }

    public List<Department> ChildDeparments { get; private set; } = [];

    public string? Path { get; private set; }

    public short Depth { get; private set; }

    public List<Guid> DepartmentLocationIds { get; private set; } = [];

    public List<Guid> DepartmentPositionIds { get; private set; } = [];

    public Department(Guid id,
                      DepartmentName name,
                      string identifier,
                      Guid? parentId = default)
        : base(id)
    {
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
    }
}
