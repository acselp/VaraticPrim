using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Filters;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
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

    public async Task<PagedList<CustomerEntity>> GetAllFiltered(CustomerFilter filter)
    {
        var query = Table.AsQueryable();

        query = query.Where(x => x.Deleted == filter.Deleted);

        return await query.ToPagedAsync(filter.PageIndex, filter.PageSize);
    }
}