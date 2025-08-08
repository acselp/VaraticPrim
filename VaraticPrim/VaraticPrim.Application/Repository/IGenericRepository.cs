using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?>             GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T>              Insert(T                   entity);
    Task<IEnumerable<T>> InsertRange(IEnumerable<T> entities);
    Task<T>              Update(T                   entity);
    Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);
    Task                 Delete(T                   entity);
    Task                 DeleteRange(IEnumerable<T> entities);
}