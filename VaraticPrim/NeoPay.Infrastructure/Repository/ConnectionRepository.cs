using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;

namespace NeoPay.Infrastructure.Repository;

public class ConnectionRepository : GenericRepository<ConnectionEntity>, IConnectionRepository
{
    private readonly DbContext _context;

    public ConnectionRepository(DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ConnectionEntity>> GetByCustomerId(int customerId)
    {
        return await _context.Set<ConnectionEntity>()
            .Where(c => c.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ConnectionEntity>> GetByUtilityId(int utilityId)
    {
        return await _context.Set<ConnectionEntity>()
            .Where(c => c.UtilityId == utilityId)
            .ToListAsync();
    }
}
