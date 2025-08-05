using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Repository;

public interface IRefreshTokenRepository : IGenericRepository<RefreshTokenEntity>
{
    public Task<RefreshTokenEntity?> GetUserByToken(string userId);
}