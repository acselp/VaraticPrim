using VaraticPrim.Application.Filters;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Domain.Paged;

namespace VaraticPrim.Application.Repository;

public interface ICustomerRepository : IGenericRepository<CustomerEntity>
{
    Task<bool>                      AccountNrExists(int           accountNr);
    Task<PagedList<CustomerEntity>> GetAllFiltered(CustomerFilter filter);
}