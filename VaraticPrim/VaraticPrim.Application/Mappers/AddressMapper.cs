using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class AddressMapper
{
    public static AddressEntity ToEntity(this UpdateAddressQuery query)
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

    public static UpdateAddressResult ToUpdateResult(this AddressEntity entity)
    {
        return new UpdateAddressResult
        {
            Id          = entity.Id,
            Street      = entity.Street,
            HouseNr     = entity.HouseNr,
            Block       = entity.Block,
            Entrance    = entity.Entrance,
            ApartmentNr = entity.ApartmentNr,
            Locality    = entity.Locality,
            District    = entity.District,
            PostalCode  = entity.PostalCode,
            Country     = entity.Country,
            LocationId  = entity.LocationId
        };
    }
}