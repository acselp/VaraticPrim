using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;
 
    public GenericRepository(DbContext context)
    {
        _context = context;
    }
 
    public async Task<T?> GetById(int id)
        => await _context.Set<T>().FindAsync(id);
 
    public IQueryable<T> Table =>
        _context.Set<T>();
 
    public async Task<T?> Find(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().FirstOrDefaultAsync(predicate);
 
    public async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().ToListAsync();
 
    public async Task Insert(T entity)
    {
        entity.CreatedOnUtc = DateTime.UtcNow;
        entity.UpdatedOnUtc = DateTime.UtcNow;
 
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }
 
    public async Task InsertRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        await _context.SaveChangesAsync();
    }
 
    public async Task Update(T entity)
    {
        entity.UpdatedOnUtc = DateTime.UtcNow;
 
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
 
    public async Task UpdateRange(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
 
    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}