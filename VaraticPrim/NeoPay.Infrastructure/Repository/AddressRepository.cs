using Microsoft.EntityFrameworkCore;
using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;

namespace NeoPay.Infrastructure.Repository;

public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
{
    private readonly DbContext _context;

    public AddressRepository(DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AddressEntity?> GetByCustomerId(int customerId)
    {
        return await _context.Set<AddressEntity>()
            .FirstOrDefaultAsync(a => a.CustomerId == customerId);
    }
}
