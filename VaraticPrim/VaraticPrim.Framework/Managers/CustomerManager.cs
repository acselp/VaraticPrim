using FluentValidation;
using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Domain.Exceptions;
using VaraticPrim.Framework.Extensions.Customer;
using VaraticPrim.Framework.Models.Customer;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework.Managers;

public class CustomerManager
{
    private readonly ContactInfoManager           _contactInfoManager;
    private readonly ICustomerRepository          _customerRepository;
    private readonly CreateCustomerModelValidator _customerValidator;
    private readonly LocationManager              _locationManager;
    private readonly ILogger<CustomerManager>     _logger;


    public CustomerManager(ILogger<CustomerManager>     logger,             LocationManager     locationManager,
                           ContactInfoManager           contactInfoManager, ICustomerRepository customerRepository,
                           CreateCustomerModelValidator customerValidator)
    {
        _logger             = logger;
        _locationManager    = locationManager;
        _contactInfoManager = contactInfoManager;
        _customerRepository = customerRepository;
        _customerValidator  = customerValidator;
    }

    public async Task<CustomerModel> Create(CreateCustomerModel model)
    {
        try
        {
            await _customerValidator.ValidateAndThrowAsync(model);

            if (await _customerRepository.AccountNrExists(model.AccountNr))
                throw new CustomerAccountNumberAlreadyExists("Account number already exists");

            var customerEntity = new CustomerEntity
            {
                AccountNr = model.AccountNr
            };

            await _customerRepository.Insert(customerEntity);

            var customerModel = customerEntity.ToModel();

            if (model.ContactInfo != null) model.ContactInfo.CustomerId = customerModel.Id;
            if (model.Location    != null) model.Location.CustomerId    = customerModel.Id;

            if (model.Location != null) customerModel.Location = await _locationManager.Create(model.Location);

            if (model.ContactInfo != null)
                customerModel.ContactInfo = await _contactInfoManager.Create(model.ContactInfo);

            return customerModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create customer.");
            throw;
        }
    }

    public async Task<List<CustomerGridModel>> GridGetAll()
    {
        return (await _customerRepository.GetAll()).Select(entity => entity.ToGridModel()).ToList();
    }
}