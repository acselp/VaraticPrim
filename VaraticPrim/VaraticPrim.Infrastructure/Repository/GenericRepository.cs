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

    public IQueryable<T> Table =>
        _context.Set<T>();

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Insert(T entity)
    {
        entity.CreatedOnUtc = DateTime.UtcNow;
        entity.UpdatedOnUtc = DateTime.UtcNow;

        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<T>> InsertRange(IEnumerable<T> entities)
    {
        var baseEntities = entities.ToList();
        _context.Set<T>().AddRange(baseEntities);
        await _context.SaveChangesAsync();

        return baseEntities;
    }

    public async Task<T> Update(T entity)
    {
        entity.UpdatedOnUtc = DateTime.UtcNow;

        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities)
    {
        var baseEntities = entities.ToList();
        _context.Set<T>().UpdateRange(baseEntities);
        await _context.SaveChangesAsync();

        return baseEntities;
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

    public async Task<T?> Find(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
}