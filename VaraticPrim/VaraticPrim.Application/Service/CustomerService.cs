using VaraticPrim.Application.Contracts.Customer;
using VaraticPrim.Application.Mappers;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Exceptions;

namespace VaraticPrim.Application.Service;

public class CustomerService
{
    private readonly IAddressRepository     _addressRepository;
    private readonly IContactInfoRepository _contactInfoRepository;
    private readonly ICustomerRepository    _customerRepository;

    public CustomerService(ICustomerRepository customerRepository, IContactInfoRepository contactInfoRepository,
                           IAddressRepository  addressRepository)
    {
        _customerRepository    = customerRepository;
        _contactInfoRepository = contactInfoRepository;
        _addressRepository     = addressRepository;
    }

    public async Task<CreateCustomerResult> Create(CreateCustomerQuery query)
    {
        if (await _customerRepository.AccountNrExists(query.AccountNr))
            throw new CustomerAccountNumberAlreadyExists("Account number already exists");

        var customerEntity = query.ToEntity();

        await _customerRepository.Insert(customerEntity);

        return customerEntity.ToCreateResult();
    }
}