using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class CustomerRepository(PostgresDbContext context)
    : GenericRepository<CustomerEntity>(context), ICustomerRepository
{
    public async Task<bool> AccountNrExists(int accountNr)
    {
        return await Table.AnyAsync(x => x.AccountNr == accountNr);
    }

    public async Task<List<CustomerEntity>> GetAllFiltered()
    {
        return await Table.ToPagedAsync(filter.PageIndex, filter.PageSize);
    }
}