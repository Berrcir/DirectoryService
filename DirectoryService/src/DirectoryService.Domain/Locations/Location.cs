using DirectoryService.Domain.Abstractions;

namespace DirectoryService.Domain.Locations;

public class Location : Entity
{
    public required string Name { get; init; }

    public required Address Address { get; init; }

    public required IanaCode TimeZone { get; init; }

    public List<Guid> DepartmenLocationtIds { get; private set; } = [];

    public Location(Guid id, string name, Address address, IanaCode timeZone)
        : base(id)
    {
        Name = name;
        Address = address;
        TimeZone = timeZone;
    }
}