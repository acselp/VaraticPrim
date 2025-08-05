using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class RefreshTokenRepository(PostgresDbContext context)
    : GenericRepository<RefreshTokenEntity>(context), IRefreshTokenRepository
{
    public async Task<RefreshTokenEntity?> GetUserByToken(string token)
    {
        return await Table.FirstOrDefaultAsync(x => x.RefreshToken.Equals(token));
    }
}