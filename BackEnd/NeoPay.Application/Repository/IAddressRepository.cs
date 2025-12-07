using NeoPay.Domain.Entities;

namespace NeoPay.Application.Repository;

public interface IAddressRepository : IGenericRepository<AddressEntity>
{
    Task<AddressEntity?> GetByCustomerId(int customerId);
}
