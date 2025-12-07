using NeoPay.Application.Repository;
using NeoPay.Domain.Entities;
using NeoPay.Domain.Exceptions;
using NeoPay.Domain.Paged;

namespace NeoPay.Application.Service;

public class UtilityService
{
    private readonly IUtilityRepository _utilityRepository;

    public UtilityService(IUtilityRepository utilityRepository)
    {
        _utilityRepository = utilityRepository;
    }

    public async Task<UtilityEntity> Create(UtilityEntity entity)
    {
        return await _utilityRepository.Insert(entity);
    }

    public async Task<UtilityEntity?> GetById(int id)
    {
        return await _utilityRepository.GetById(id);
    }

    public async Task<IEnumerable<UtilityEntity>> GetAll()
    {
        return await _utilityRepository.GetAll();
    }

    public async Task<PagedList<UtilityEntity>> GetAll(PagedFilter filter)
    {
        return await _utilityRepository.GetAll(filter);
    }

    public async Task<UtilityEntity> Update(UtilityEntity entity)
    {
        var existingUtility = await _utilityRepository.GetById(entity.Id);
        if (existingUtility == null)
            throw new NotFoundException($"Utility with ID {entity.Id} not found");

        return await _utilityRepository.Update(entity);
    }

    public async Task Delete(int id)
    {
        var utility = await _utilityRepository.GetById(id);
        if (utility == null)
            throw new NotFoundException($"Utility with ID {id} not found");

        await _utilityRepository.Delete(utility);
    }
}