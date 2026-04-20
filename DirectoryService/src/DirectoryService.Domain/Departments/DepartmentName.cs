using CSharpFunctionalExtensions;
using SeatsReservationService.Domain.Constants;
using Shared;
using System.Diagnostics.CodeAnalysis;

namespace DirectoryService.Domain.Departments;

public record class DepartmentName
{
    public required string ManagementUnit { get; init; }

    public required string Direction { get; init; }

    [SetsRequiredMembers]
    private DepartmentName(string managementUnit, string direction)
    {
        ManagementUnit = managementUnit;
        Direction = direction;
    }

    public static Result<DepartmentName, Error> Create(
        string managementUnit,
        string direction)
    {
        const int MIN_NAME_LENGTH = LengthConstants.LENGTH_3;
        const int MAX_NAME_LENGTH = LengthConstants.LENGTH_150;

        if (managementUnit is null)
        {
            return Error.Validation("department.name", "ManagmentUnit can not be null", nameof(managementUnit));
        }

        if (direction is null)
        {
            return Error.Validation("department.name", "Direction can not be null", nameof(direction));
        }

        int departmentNameLength = managementUnit.Length + direction.Length;

        if (departmentNameLength < MIN_NAME_LENGTH && departmentNameLength > MAX_NAME_LENGTH)
        {
            return Error.Validation("department.name", $"Department name must be {MIN_NAME_LENGTH}-{MAX_NAME_LENGTH} symbols", nameof(DepartmentName));
        }

        return new DepartmentName(managementUnit, direction);
    }
}