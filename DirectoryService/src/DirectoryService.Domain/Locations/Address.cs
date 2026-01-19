namespace DirectoryService.Domain.Locations;

public record class Address
{
    public required string PostalCode { get; init; }

    public required string Country { get; init; }

    public required string Region { get; init; }

    public required string Locality { get; init; }

    public required string Street { get; init; }

    public required int HouseNumber { get; init; }

    public required int? AppartmentNumber { get; init; }

}
