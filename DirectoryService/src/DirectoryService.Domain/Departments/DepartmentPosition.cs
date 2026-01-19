namespace DirectoryService.Domain.Departments;

public record class DepartmentPosition
{
    public required Guid DepartmentId { get; init; }

    public required Guid PositionId { get; init; }

}
