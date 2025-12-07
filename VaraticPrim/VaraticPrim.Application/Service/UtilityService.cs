using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;

namespace VaraticPrim.Application.Service;

public class UtilityService
{
    private readonly IUtilityRepository _utilityRepository;

    public UtilityService(IUtilityRepository utilityRepository)
    {
        _utilityRepository = utilityRepository;
    }

    public async Task Create(UtilityEntity entity)
    {
        await _utilityRepository.Insert(entity);
    }
}