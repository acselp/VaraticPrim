using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class AddressMapper
{
    public static AddressEntity ToEntity(this CreateAddressQuery query)
    {
        return new AddressEntity
        {
            Street      = query.Street,
            HouseNr     = query.HouseNr,
            Block       = query.Block,
            Entrance    = query.Entrance,
            ApartmentNr = query.ApartmentNr,
            Locality    = query.Locality,
            District    = query.District,
            PostalCode  = query.PostalCode,
            Country     = query.Country,
            LocationId  = query.LocationId
        };
    }
}