using NeoPay.Domain.Entities;

namespace NeoPay.Application.Repository;

public interface ICustomerRepository : IGenericRepository<CustomerEntity>
{
    Task<bool> AccountNrExists(int accountNr);
}