using FluentValidation;
using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Service;
using VaraticPrim.Framework.Mappers;
using VaraticPrim.Framework.Models.Customer;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework.Managers;

public class CustomerManager
{
    private readonly CustomerService              _customerService;
    private readonly CreateCustomerModelValidator _customerValidator;
    private readonly ILogger<CustomerManager>     _logger;


    public CustomerManager(ILogger<CustomerManager> logger, CreateCustomerModelValidator customerValidator,
                           CustomerService          customerService)
    {
        _logger            = logger;
        _customerValidator = customerValidator;
        _customerService   = customerService;
    }

    public async Task<CustomerModel> Create(CreateCustomerModel model)
    {
        try
        {
            await _customerValidator.ValidateAndThrowAsync(model);

            var query = model.ToQuery();

            return (await _customerService.Create(query)).ToModel();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create customer.");
            throw;
        }
    }
}