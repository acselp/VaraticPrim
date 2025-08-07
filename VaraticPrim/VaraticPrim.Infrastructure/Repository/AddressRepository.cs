using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class AddressRepository(PostgresDbContext context)
    : GenericRepository<AddressEntity>(context), IAddressRepository
{
}