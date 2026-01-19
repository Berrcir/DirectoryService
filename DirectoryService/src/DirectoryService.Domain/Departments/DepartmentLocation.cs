namespace DirectoryService.Domain.Departments;

public record class DepartmentLocation
{
    public required Guid DepartmentId { get; init; }

    public required Guid LocationId { get; init; }
}
