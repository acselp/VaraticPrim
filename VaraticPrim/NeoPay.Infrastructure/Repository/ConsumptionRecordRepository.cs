using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;

namespace NeoPay.Infrastructure.Repository;

public class ConsumptionRecordRepository : GenericRepository<ConsumptionRecord>, IConsumptionRecordRepository
{
    private readonly DbContext _context;

    public ConsumptionRecordRepository(DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ConsumptionRecord>> GetByMeterId(int meterId)
    {
        return await _context.Set<ConsumptionRecord>()
            .Where(cr => cr.MeterId == meterId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ConsumptionRecord>> GetByMeterIdAndDateRange(int meterId, DateTime startDate, DateTime endDate)
    {
        return await _context.Set<ConsumptionRecord>()
            .Where(cr => cr.MeterId == meterId &&
                        cr.CreatedOnUtc >= startDate &&
                        cr.CreatedOnUtc <= endDate)
            .ToListAsync();
    }
}
