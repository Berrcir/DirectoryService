using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using SeatsReservationService.Domain.Constants;
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

    // EF Core
    private Location()
    {
    }

    [SetsRequiredMembers]
    private Location(
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
        const int MIN_NAME_LENGTH = LengthConstants.LENGTH_3;
        const int MAX_NAME_LENGTH = LengthConstants.LENGTH_120;

        if (name is null)
        {
            return Error.Validation("location.name", $"Name can not be null", nameof(name));
        }

        if (name.Length < MIN_NAME_LENGTH && name.Length > MAX_NAME_LENGTH)
        {
            return Error.Validation("department.name", $"Department name must be {MIN_NAME_LENGTH}-{MAX_NAME_LENGTH} symbols", nameof(DepartmentName));
        }

        return new Location(name, address, timeZone);
    }
}