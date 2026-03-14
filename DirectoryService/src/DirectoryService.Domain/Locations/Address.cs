using System.Diagnostics.CodeAnalysis;

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

    [SetsRequiredMembers]
    public Address(
        string postalCode,
        string country,
        string region,
        string locality,
        string street,
        int houseNumber,
        int? appartmentNumber = null)
    {
        PostalCode = postalCode;
        Country = country;
        Region = region;
        Locality = locality;
        Street = street;
        HouseNumber = houseNumber;
        AppartmentNumber = appartmentNumber;
    }
}
