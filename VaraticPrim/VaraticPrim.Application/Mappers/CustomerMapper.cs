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
            ContactInfo = query.ContactInfo.ToEntity()
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
}