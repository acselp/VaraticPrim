using FluentValidation;
using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Framework.Extensions.Address;
using VaraticPrim.Framework.Models.Address;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework.Managers;

public class AddressManager
{
    private readonly IAddressRepository          _addressRepository;
    private readonly CreateAddressModelValidator _addressValidator;
    private readonly ILogger<AddressManager>     _logger;

    public AddressManager(IAddressRepository          addressRepository, ILogger<AddressManager> logger,
                          CreateAddressModelValidator addressValidator)
    {
        _addressRepository = addressRepository;
        _logger            = logger;
        _addressValidator  = addressValidator;
    }

    public async Task<AddressModel> Create(CreateAddressModel model)
    {
        try
        {
            await _addressValidator.ValidateAndThrowAsync(model);
            return (await _addressRepository.Insert(model.ToEntity())).ToModel();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create address");
            throw;
        }
    }
}