using VaraticPrim.Application.Contracts.Customer;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Mappers;

public static class CustomerMapper
{
    public static CustomerEntity ToEntity(this CreateCustomerQuery query)
    {
        return new CustomerEntity
        {
            AccountNr   = query.AccountNr,
            ContactInfo = query.ContactInfo.ToEntity(),
            Location    = new LocationEntity()
        };
    }

    public static CustomerEntity ToEntity(this UpdateCustomerQuery query)
    {
        return new CustomerEntity
        {
            Id          = query.Id,
            AccountNr   = query.AccountNr,
            ContactInfo = query.ContactInfo.ToEntity(),
            Location    = query.Location?.ToEntity()
        };
    }

    public static CreateCustomerResult ToCreateResult(this CustomerEntity entity)
    {
        return new CreateCustomerResult
        {
            Id          = entity.Id,
            AccountNr   = entity.AccountNr,
            ContactInfo = entity.ContactInfo.ToCreateResult()
        };
    }

    public static UpdateCustomerResult ToUpdateResult(this CustomerEntity entity)
    {
        return new UpdateCustomerResult
        {
            Id          = entity.Id,
            AccountNr   = entity.AccountNr,
            ContactInfo = entity.ContactInfo.ToUpdateResult(),
            Location    = entity.Location?.ToUpdateResult()
        };
    }
}