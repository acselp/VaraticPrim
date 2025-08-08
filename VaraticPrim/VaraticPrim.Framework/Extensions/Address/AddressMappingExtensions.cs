using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.Location;
using VaraticPrim.Framework.Models.Address;

namespace VaraticPrim.Framework.Extensions.Address;

public static class AddressMappingExtensions
{
    public static AddressEntity ToEntity(this CreateAddressModel model)
    {
        return new AddressEntity
        {
            Street      = model.Street,
            HouseNr     = model.HouseNr,
            Block       = model.Block,
            Entrance    = model.Entrance,
            ApartmentNr = model.ApartmentNr,
            Locality    = model.Locality,
            District    = model.District,
            PostalCode  = model.PostalCode,
            Country     = model.Country
        };
    }

    public static AddressModel ToModel(this AddressEntity entity)
    {
        return new AddressModel
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

            Location = entity.Location.ToModel()
        };
    }
}