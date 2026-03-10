using CSharpFunctionalExtensions;
using Shared;
using System.Diagnostics.CodeAnalysis;

namespace DirectoryService.Domain.Positions;

public class Position
{
    public required PositionId Id { get; init; }

    public required PositionName Name { get; init; }

    public string? Description { get; private set; }

    public bool IsActive { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; private set; }

    [SetsRequiredMembers]
    public Position(
        PositionName name,
        string? description = default)
    {
        DateTime utcTime = DateTime.UtcNow;

        Id = new PositionId(Guid.NewGuid());
        Name = name;
        Description = description;

        IsActive = true;
        CreatedAt = utcTime;
        UpdatedAt = utcTime;
    }

    public static Result<Position, Error> Create(
        string speciality,
        string direction,
        string description)
    {
        #region DESCRIPTION_VALIDATION

        const int MAX_DESCRIPTION_LENGTH = 1000;

        if (description?.Length <= MAX_DESCRIPTION_LENGTH)
        {
            return Error.Validation("position.description", $"Description length must be less or equals {MAX_DESCRIPTION_LENGTH}", nameof(description));
        }

        #endregion

        var positionNameResult = PositionName.Create(speciality, direction);

        if (positionNameResult.IsFailure)
        {
            return positionNameResult.Error;
        }

        return new Position(positionNameResult.Value, description);
    }
}
