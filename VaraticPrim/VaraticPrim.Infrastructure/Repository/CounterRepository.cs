using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class CounterRepository(PostgresDbContext context)
    : GenericRepository<CounterEntity>(context), ICounterRepository
{
}