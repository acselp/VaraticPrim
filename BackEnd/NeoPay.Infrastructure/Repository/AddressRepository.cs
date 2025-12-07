using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Infrastructure.Persistence;

namespace NeoPay.Infrastructure.Repository;

public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
{
    private readonly PostgresDbContext _context;

    public AddressRepository(PostgresDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AddressEntity?> GetByCustomerId(int customerId)
    {
        return await _context.Set<AddressEntity>()
            .FirstOrDefaultAsync(a => a.CustomerId == customerId);
    }
}
