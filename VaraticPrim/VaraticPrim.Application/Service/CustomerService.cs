using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Domain.Filters;

namespace VaraticPrim.Application.Service;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Create(CustomerEntity entity)
    {
        if (await _customerRepository.AccountNrExists(entity.AccountNr))
            throw new
                CustomerAccountNumberAlreadyExists($"Customer with account number: {entity.AccountNr} already exists");

        await _customerRepository.Insert(entity);
    }

    public async Task<IList<CustomerEntity>> GetAll(CustomerGetAllFilter filter)
    {
        return await _customerRepository.GetAll(filter);
    }
}