namespace DirectoryService.Domain.Departments;

public record class DepartmentName
{
    public required string ManagmentUnit { get; init; }

    public required string Direction { get; init; }
}