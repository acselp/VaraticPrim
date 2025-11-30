using VaraticPrim.Application.Contracts.Customer;
using VaraticPrim.Framework.Models.Customer;

namespace VaraticPrim.Framework.Mappers;

public static class CustomerMapper
{
    public static CustomerModel ToModel(this CreateCustomerResult result)
    {
        return new CustomerModel
        {
            Id          = result.Id,
            AccountNr   = result.AccountNr,
            ContactInfo = result.ContactInfo.ToModel()
        };
    }

    public static CustomerModel ToModel(this UpdateCustomerResult result)
    {
        return new CustomerModel
        {
            Id          = result.Id,
            AccountNr   = result.AccountNr,
            ContactInfo = result.ContactInfo.ToModel(),
            Location    = result.Location?.ToModel()
        };
    }

    public static CustomerModel ToModel(this GetCustomerResult result)
    {
        return new CustomerModel
        {
            Id          = result.Id,
            AccountNr   = result.AccountNr,
            ContactInfo = result.ContactInfo.ToModel(),
            Location    = result.Location?.ToModel()
        };
    }

    public static CreateCustomerQuery ToQuery(this CreateCustomerModel model)
    {
        return new CreateCustomerQuery
        {
            AccountNr   = model.AccountNr,
            ContactInfo = model.ContactInfo.ToQuery()
        };
    }

    public static UpdateCustomerQuery ToQuery(this UpdateCustomerModel model)
    {
        return new UpdateCustomerQuery
        {
            AccountNr   = model.AccountNr,
            ContactInfo = model.ContactInfo.ToQuery(),
            Location    = model.Location?.ToQuery()
        };
    }
}