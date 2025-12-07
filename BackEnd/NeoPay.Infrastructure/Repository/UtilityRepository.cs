using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Infrastructure.Persistence;

namespace NeoPay.Infrastructure.Repository;

public class UtilityRepository : GenericRepository<UtilityEntity>, IUtilityRepository
{
    public UtilityRepository(PostgresDbContext context) : base(context)
    {
    }
}
