using VaraticPrim.Application.Contracts.ContactInfo;
using VaraticPrim.Framework.Models.ContactInfo;

namespace VaraticPrim.Framework.Mappers;

public static class ContactInfoMapper
{
    public static ContactInfoModel ToModel(this CreateContactInfoResult result)
    {
        return new ContactInfoModel
        {
            Id        = result.Id,
            FirstName = result.FirstName,
            LastName  = result.LastName,
            Mobile    = result.Mobile,
            Phone     = result.Phone
        };
    }

    public static CreateContactInfoQuery ToContract(this CreateContactInfoModel model)
    {
        return new CreateContactInfoQuery
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Mobile    = model?.Mobile,
            Phone     = model?.Phone
        };
    }
}