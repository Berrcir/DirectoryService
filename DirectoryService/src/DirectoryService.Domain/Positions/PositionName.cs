namespace DirectoryService.Domain.Positions;

public record class PositionName
{
    public required string Speciality { get; init; }

    public required string Direction { get; init; }
}