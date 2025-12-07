using NeoPay.Domain.Entities;

namespace NeoPay.Application.Repository;

public interface IConsumptionRecordRepository : IGenericRepository<ConsumptionRecord>
{
    Task<IEnumerable<ConsumptionRecord>> GetByMeterId(int meterId);
    Task<IEnumerable<ConsumptionRecord>> GetByMeterIdAndDateRange(int meterId, DateTime startDate, DateTime endDate);
}
