using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Domain.Filters;
using VaraticPrim.Domain.Paged;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class CustomerRepository(PostgresDbContext context)
    : GenericRepository<CustomerEntity>(context), ICustomerRepository
{
    public async Task<bool> AccountNrExists(int accountNr)
    {
        return await Table.AnyAsync(x => x.AccountNr == accountNr);
    }

    public Task<PagedList<CustomerEntity>> GetAll(CustomerGetAllFilter filter)
    {
        var query = Table;

        query = query.Where(x => x.AccountNr > 0);

        return query.ToPagedAsync(filter.PageIndex, filter.PageSize);
    }
}