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

    public async Task<CustomerEntity> Create(CustomerEntity entity)
    {
        if (await _customerRepository.AccountNrExists(entity.AccountNr))
            throw new
                CustomerAccountNumberAlreadyExists($"Customer with account number: {entity.AccountNr} already exists");

        return await _customerRepository.Insert(entity);
    }

    public async Task<CustomerEntity> GetById(int id)
    {
        var entity = await _customerRepository.GetById(id);
        if (entity == null)
            throw new NotFoundException($"Customer with ID {id} not found");

        return entity;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAll()
    {
        return await _customerRepository.GetAll();
    }

    public async Task<PagedList<CustomerEntity>> GetAll(PagedFilter filter)
    {
        return await _customerRepository.GetAll(filter);
    }

    public async Task<CustomerEntity> Update(CustomerEntity entity)
    {
        var existingCustomer = await _customerRepository.GetById(entity.Id);
        if (existingCustomer == null)
            throw new NotFoundException($"Customer with ID {entity.Id} not found");

        return await _customerRepository.Update(entity);
    }

    public async Task Delete(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer == null)
            throw new NotFoundException($"Customer with ID {id} not found");

        await _customerRepository.Delete(customer);
    }
}