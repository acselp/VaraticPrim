using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Domain.Exceptions;
using NeoPay.Domain.Filters;
using NeoPay.Domain.Paged;

namespace NeoPay.Application.Service;

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

    public async Task<PagedList<CustomerEntity>> GetAll(CustomerGetAllFilter filter)
    {
        return await _customerRepository.GetAll(filter);
    }
}