using VaraticPrim.Application.Contracts.ContactInfo;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class ContactInfoMapper
{
    public static ContactInfoEntity ToEntity(this CreateContactInfoQuery query)
    {
        return new ContactInfoEntity
        {
            FirstName  = query.FirstName,
            LastName   = query.LastName,
            Phone      = query.Phone,
            Mobile     = query.Mobile,
            CustomerId = query.CustomerId
        };
    }

    public static CreateContactInfoResult ToCreateResult(this ContactInfoEntity entity)
    {
        return new CreateContactInfoResult
        {
            Id         = entity.Id,
            FirstName  = entity.FirstName,
            LastName   = entity.LastName,
            Phone      = entity.Phone,
            Mobile     = entity.Mobile,
            CustomerId = entity.CustomerId
        };
    }
}