using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.Customer;
using VaraticPrim.Framework.Models.ContactInfo;

namespace VaraticPrim.Framework.Extensions.ContactInfo;

public static class ContactInfoMappingExtensions
{
    public static ContactInfoModel ToModel(this ContactInfoEntity entity)
    {
        return new ContactInfoModel
        {
            Id        = entity.Id,
            Mobile    = entity.Mobile,
            Phone     = entity.Phone,
            FirstName = entity.FirstName,
            LastName  = entity.LastName,

            Customer = entity.Customer.ToModel()
        };
    }

    public static ContactInfoEntity ToEntity(this CreateContactInfoModel model)
    {
        return new ContactInfoEntity
        {
            Mobile    = model.Mobile,
            Phone     = model.Phone,
            FirstName = model.FirstName,
            LastName  = model.LastName
        };
    }
}