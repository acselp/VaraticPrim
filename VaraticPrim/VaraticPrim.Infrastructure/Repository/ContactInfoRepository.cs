using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class ContactInfoRepository(PostgresDbContext context)
    : GenericRepository<ContactInfoEntity>(context), IContactInfoRepository
{
}