using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Repository;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    public Task<UserEntity?> GetByEmail(string          email);
    public Task<bool>        UserWithEmailExists(string email);
}