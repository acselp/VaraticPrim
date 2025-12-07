using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;

namespace NeoPay.Infrastructure.Repository;

public class MeterRepository : GenericRepository<MeterEntity>, IMeterRepository
{
    private readonly DbContext _context;

    public MeterRepository(DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MeterEntity>> GetByConnectionId(int connectionId)
    {
        return await _context.Set<MeterEntity>()
            .Where(m => m.ConnectionId == connectionId)
            .ToListAsync();
    }

    public async Task<MeterEntity?> GetBySerialNumber(string serialNumber)
    {
        return await _context.Set<MeterEntity>()
            .FirstOrDefaultAsync(m => m.SerialNumber == serialNumber);
    }
}
