using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using Shared;
using System.Diagnostics.CodeAnalysis;

namespace DirectoryService.Domain.Locations;

public class Location
{
    public required LocationId Id { get; init; }

    public required string Name { get; init; }

    public required Address Address { get; init; }

    public required IanaCode TimeZone { get; init; }

    public required bool IsActive { get; init; }

    public required DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; private set; }

    [SetsRequiredMembers]
    public Location(
        string name,
        Address address,
        IanaCode timeZone)
    {
        DateTime utcTime = DateTime.UtcNow;

        Id = new LocationId(Guid.NewGuid());
        Name = name;
        Address = address;
        TimeZone = timeZone;

        IsActive = true;
        CreatedAt = utcTime;
        UpdatedAt = utcTime;
    }

    public static Result<Location, Error> Create(
        string name,
        Address address,
        IanaCode timeZone)
    {
        #region NAME_VALIDATION

        const int MIN_NAME_LENGTH = 3;
        const int MAX_NAME_LENGTH = 120;

        if (name is null)
        {
            return Error.Validation("location.name", $"Name can not be null", nameof(name));
        }

        if (name.Length < MIN_NAME_LENGTH && name.Length > MAX_NAME_LENGTH)
        {
            return Error.Validation("department.name", $"Department name must be {MIN_NAME_LENGTH}-{MAX_NAME_LENGTH} symbols", nameof(DepartmentName));
        }

        #endregion

        return new Location(name, address, timeZone);
    }
}