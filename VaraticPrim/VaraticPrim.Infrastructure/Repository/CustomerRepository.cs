using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class CustomerRepository(PostgresDbContext context)
    : GenericRepository<CustomerEntity>(context), ICustomerRepository
{
}