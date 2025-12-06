using VaraticPrim.Application.Contracts.Customer;
using VaraticPrim.Application.Mappers;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Exceptions;

namespace VaraticPrim.Application.Service;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CreateCustomerResult> Create(CreateCustomerQuery query)
    {
        if (await _customerRepository.AccountNrExists(query.AccountNr))
            throw new CustomerAccountNumberAlreadyExists("Account number already exists");

        var customerEntity = query.ToEntity();

        await _customerRepository.Insert(customerEntity);

        return customerEntity.ToCreateResult();
    }

    public async Task<UpdateCustomerResult> Update(UpdateCustomerQuery query)
    {
        if (await _customerRepository.AccountNrExists(query.AccountNr))
            throw new CustomerAccountNumberAlreadyExists("Account number already exists");

        var customerEntity = query.ToEntity();

        await _customerRepository.Update(customerEntity);

        return customerEntity.ToUpdateResult();
    }
}