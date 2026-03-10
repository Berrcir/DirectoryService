using CSharpFunctionalExtensions;
using Shared;
using System.Diagnostics.CodeAnalysis;

namespace DirectoryService.Domain.Positions;

public record class PositionName
{
    public required string Speciality { get; init; }

    public required string Direction { get; init; }

    [SetsRequiredMembers]
    private PositionName(string speciality, string direction)
    {
        Speciality = speciality;
        Direction = direction;
    }

    public static Result<PositionName, Error> Create(
        string speciality,
        string direction)
    {
        const int MIN_NAME_LENGTH = 3;
        const int MAX_NAME_LENGTH = 120;

        if (speciality is null)
        {
            return Error.Validation("position.name", "Speciality can not be null", nameof(speciality));
        }

        if (direction is null)
        {
            return Error.Validation("position.name", "Direction can not be null", nameof(direction));
        }

        int positionNameLength = speciality.Length + direction.Length;

        if (positionNameLength < MIN_NAME_LENGTH && positionNameLength > MAX_NAME_LENGTH)
        {
            return Error.Validation("position.name", $"Department name must be {MIN_NAME_LENGTH}-{MAX_NAME_LENGTH} symbols", nameof(PositionName));
        }

        return new PositionName(speciality, direction);
    }
}