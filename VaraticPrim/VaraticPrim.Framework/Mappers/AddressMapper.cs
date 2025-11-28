using VaraticPrim.Application.Contracts.Address;
using VaraticPrim.Framework.Models.Address;

namespace VaraticPrim.Framework.Mappers;

public static class AddressMapper
{
    public static UpdateAddressQuery ToQuery(this UpdateAddressModel model)
    {
        return new UpdateAddressQuery
        {
            Id          = model.Id,
            ApartmentNr = model.ApartmentNr,
            Block       = model.Block,
            Country     = model.Country,
            District    = model.District,
            Entrance    = model.Entrance,
            HouseNr     = model.HouseNr,
            Locality    = model.Locality,
            PostalCode  = model.PostalCode,
            LocationId  = model.LocationId,
            Street      = model.Street
        };
    }

    public static AddressModel ToModel(this UpdateAddressResult model)
    {
        return new AddressModel
        {
            Id          = model.Id,
            ApartmentNr = model.ApartmentNr,
            Block       = model.Block,
            Country     = model.Country,
            District    = model.District,
            Entrance    = model.Entrance,
            HouseNr     = model.HouseNr,
            Locality    = model.Locality,
            PostalCode  = model.PostalCode,
            LocationId  = model.LocationId,
            Street      = model.Street
        };
    }
}