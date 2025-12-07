using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Domain.Filters;
using NeoPay.Domain.Paged;
using NeoPay.Infrastructure.Persistence;

namespace NeoPay.Infrastructure.Repository;

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