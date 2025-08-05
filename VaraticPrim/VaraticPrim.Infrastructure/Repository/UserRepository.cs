using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Infrastructure.Persistence;

namespace VaraticPrim.Infrastructure.Repository;

public class UserRepository(PostgresDbContext context) : GenericRepository<UserEntity>(context), IUserRepository
{
    public async Task<UserEntity?> GetByEmail(string email)
    {
        return await Table.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> UserWithEmailExists(string email)
    {
        return await Table.AnyAsync(x => x.Email == email);
    }
}