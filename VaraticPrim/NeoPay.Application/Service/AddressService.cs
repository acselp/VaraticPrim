using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Domain.Exceptions;
using NeoPay.Domain.Paged;

namespace NeoPay.Application.Service;

public class AddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ICustomerRepository _customerRepository;

    public AddressService(IAddressRepository addressRepository, ICustomerRepository customerRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }

    public async Task<AddressEntity> Create(AddressEntity entity)
    {
        var customer = await _customerRepository.GetById(entity.CustomerId);
        if (customer == null)
            throw new NotFoundException($"Customer with ID {entity.CustomerId} not found");

        return await _addressRepository.Insert(entity);
    }

    public async Task<AddressEntity> GetById(int id)
    {
        var entity = await _addressRepository.GetById(id);
        
        if (entity == null)
            throw new NotFoundException($"Address with ID {id} not found");
        
        return entity;
    }

    public async Task<IEnumerable<AddressEntity>> GetAll()
    {
        return await _addressRepository.GetAll();
    }

    public async Task<PagedList<AddressEntity>> GetAll(PagedFilter filter)
    {
        return await _addressRepository.GetAll(filter);
    }

    public async Task<AddressEntity?> GetByCustomerId(int customerId)
    {
        return await _addressRepository.GetByCustomerId(customerId);
    }

    public async Task<AddressEntity> Update(AddressEntity entity)
    {
        var existingAddress = await _addressRepository.GetById(entity.Id);
        if (existingAddress == null)
            throw new NotFoundException($"Address with ID {entity.Id} not found");

        var customer = await _customerRepository.GetById(entity.CustomerId);
        if (customer == null)
            throw new NotFoundException($"Customer with ID {entity.CustomerId} not found");

        return await _addressRepository.Update(entity);
    }

    public async Task Delete(int id)
    {
        var address = await _addressRepository.GetById(id);
        if (address == null)
            throw new NotFoundException($"Address with ID {id} not found");

        await _addressRepository.Delete(address);
    }
}
