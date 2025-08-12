using FluentValidation;
using Microsoft.Extensions.Logging;
using VaraticPrim.Application.Repository;
using VaraticPrim.Domain.Entities;
using VaraticPrim.Framework.Extensions.ContactInfo;
using VaraticPrim.Framework.Models.ContactInfo;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework.Managers;

public class ContactInfoManager
{
    private readonly CreateContactInfoModelValidator _contactInfoModelValidator;
    private readonly IContactInfoRepository          _contactInfoRepository;
    private readonly ILogger<ContactInfoManager>     _logger;

    public ContactInfoManager(ILogger<ContactInfoManager>     logger, IContactInfoRepository contactInfoRepository,
                              CreateContactInfoModelValidator contactInfoModelValidator)
    {
        _logger                    = logger;
        _contactInfoRepository     = contactInfoRepository;
        _contactInfoModelValidator = contactInfoModelValidator;
    }

    public async Task<ContactInfoModel> Create(CreateContactInfoModel model)
    {
        try
        {
            await _contactInfoModelValidator.ValidateAndThrowAsync(model);

            var contactInfoEntity = new ContactInfoEntity
            {
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Phone = model.Phone
            };

            await _contactInfoRepository.Insert(contactInfoEntity);
            
            return contactInfoEntity.ToModel();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create contact info");
            throw;
        }
    }
}