using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;

namespace NeoPay.Infrastructure.Repository;

public class UtilityRepository : GenericRepository<UtilityEntity>, IUtilityRepository
{
    public UtilityRepository(DbContext context) : base(context)
    {
    }
}
