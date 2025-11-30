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

    public static ContactInfoModel ToModel(this UpdateContactInfoResult result)
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

    public static ContactInfoModel ToModel(this GetContactInfoResult result)
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

    public static CreateContactInfoQuery ToQuery(this CreateContactInfoModel model)
    {
        return new CreateContactInfoQuery
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Mobile    = model?.Mobile,
            Phone     = model?.Phone
        };
    }

    public static UpdateContactInfoQuery ToQuery(this UpdateContactInfoModel model)
    {
        return new UpdateContactInfoQuery
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Mobile    = model?.Mobile,
            Phone     = model?.Phone
        };
    }
}