using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class LocationRepository(PostgresDbContext context)
    : GenericRepository<LocationEntity>(context), ILocationRepository
{
}