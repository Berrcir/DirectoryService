using System.Diagnostics.CodeAnalysis;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.Departments;

public class Department
{
    private readonly List<Department> _childDepartments = [];

    private readonly List<DepartmentPosition> _positions = [];

    private readonly List<DepartmentLocation> _locations = [];

    public required DepartmentId Id { get; init; }

    public required DepartmentName Name { get; init; }

    public required string Identifier { get; init; }

    public DepartmentId? ParentId { get; private set; }

    public Department? Parent { get; private set; }

    public IReadOnlyList<Department> ChildDeparments => _childDepartments;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public string Path { get; private set; }

    public short Depth { get; private set; }

    public required bool IsActive { get; init; }

    public required DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; private set; }

    [SetsRequiredMembers]
    private Department(
        DepartmentName name,
        string identifier,
        Department? parent = default)
    {
        DateTime utcTime = DateTime.UtcNow;

        Id = new DepartmentId(Guid.NewGuid());
        Name = name;
        Identifier = identifier;
        Parent ??= parent;
        ParentId ??= parent?.Id;
        Path = parent?.Path + identifier;
        Depth = parent?.Depth ?? 0 + 1;

        IsActive = true;
        CreatedAt = utcTime;
        UpdatedAt = utcTime;
    }

    public static Result<Department, Error> Create(
        string managementUnit,
        string direction,
        string identifier,
        Department? parent = default)
    {
        #region IDENTIFIER_VALIDATION

        if (identifier is null)
        {
            return Error.Validation("department.identifier", "Identifier can not be null", nameof(identifier));
        }

        if (identifier.Length < 3 && identifier.Length > 150)
        {
            return Error.Validation("department.identifier", "Identifier must be 3-150 symbols", nameof(identifier));
        }

        if (RegularExpressionsExtensions.NonLatinSymbolsRegex.IsMatch(identifier))
        {
            return Error.Validation("department.identifier", "identifier should use only latin symbols", nameof(identifier));
        }

        #endregion

        var departmentNameResult = DepartmentName.Create(managementUnit, direction);

        if (departmentNameResult.IsFailure)
        {
            return departmentNameResult.Error;
        }

        return new Department(departmentNameResult.Value, identifier, parent);
    }
}
