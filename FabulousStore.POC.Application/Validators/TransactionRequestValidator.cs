using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.DomainTransferObjects;
using FabulousStore.POC.Core.Repositories;
using FluentValidation;

namespace FabulousStore.POC.Core.Validators
{
    internal class TransactionRequestValidator : AbstractValidator<TransactionRequestDTO>
    {
        private readonly ITenantService _tenantService;
        //private readonly ITenantRepository _tenantRepository;

        public TransactionRequestValidator(ITenantService tenantService)
        {
            _tenantService = tenantService;           

            RuleFor(t => t.TenantId).NotEmpty();
            RuleFor(t => t.TransactionId).NotEmpty();
            RuleFor(t => t.Direction).NotEmpty();

            RuleFor(t => t).Must(ValidateDailyLimit).WithMessage("Daily max limit reached");
            RuleFor(t => t).Must(ValidateThresholdLimit).WithMessage("Max Threshold limit exceed");
            RuleFor(t => t).Must(ValidateSanctionCountry).WithMessage("Transaction can't perform out of sanction country");
        }

        private bool ValidateDailyLimit(TransactionRequestDTO transaction)
        {
            var tenantSetting = _tenantService.GetTenantSettingAsync(transaction.TenantId).GetAwaiter().GetResult();

            if (tenantSetting != null)
            {
                // Get Daily Aggregated Total Transaction Value = _tenantRepository.GetAggregatedTotalAmount()
                var aggregatedTotal = 0;

                return tenantSetting.VelocityLimits.Daily >= transaction.Amount + aggregatedTotal;
            }

            return false;
        }

        private bool ValidateThresholdLimit(TransactionRequestDTO transaction)
        {
            var tenantSetting = _tenantService.GetTenantSettingAsync(transaction.TenantId).GetAwaiter().GetResult();

            if (tenantSetting != null)
            {
                return tenantSetting.Thresholds.PerTransaction > transaction.Amount;
            }

            return false;
        }

        private bool ValidateSanctionCountry(TransactionRequestDTO transaction)
        {
            var tenantSetting = _tenantService.GetTenantSettingAsync(transaction.TenantId).GetAwaiter().GetResult();

            if (tenantSetting != null && transaction.Sourceaccount != null && transaction.Destinationaccount != null)
            {
                var allowedSourceCountries = tenantSetting.CountrySanctions.SourceCountryCode.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var allowedDestinationCountries = tenantSetting.CountrySanctions.DestinationCountryCode.Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (allowedSourceCountries.Any(t => t.Trim().Equals(transaction.Sourceaccount.Countrycode, StringComparison.CurrentCultureIgnoreCase)) &&
                    allowedDestinationCountries.Any(t => t.Trim().Equals(transaction.Destinationaccount.Countrycode, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
