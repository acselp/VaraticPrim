using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.Location;
using VaraticPrim.Framework.Models.Location;

namespace VaraticPrim.Framework.Managers;

public class LocationManager
{
    private readonly AddressManager           _addressManager;
    private readonly ILocationRepository      _locationRepository;
    private readonly ILogger<LocationManager> _logger;

    public LocationManager(ILocationRepository locationRepository, ILogger<LocationManager> logger,
                           AddressManager      addressManager)
    {
        _locationRepository = locationRepository;
        _logger             = logger;
        _addressManager     = addressManager;
    }

    public async Task<LocationModel> Create(CreateLocationModel model)
    {
        try
        {
            var addressModel = _addressManager.Create(model.Address);
            var locationEntity = new LocationEntity
            {
                AddressId = addressModel.Id
            };
            return (await _locationRepository.Insert(locationEntity)).ToModel();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create location");
            throw;
        }
    }
}