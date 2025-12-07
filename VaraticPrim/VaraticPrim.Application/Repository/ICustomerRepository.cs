using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Repository;

public interface ICustomerRepository : IGenericRepository<CustomerEntity>
{
    Task<bool> AccountNrExists(int accountNr);
}