namespace DirectoryService.Domain.Locations;

public record class IanaCode
{
    public required string Region { get; init; }

    public required string Place { get; init; }
}
