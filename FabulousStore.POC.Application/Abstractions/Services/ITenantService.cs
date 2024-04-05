using FabulousStore.POC.Core.Configurations;

namespace FabulousStore.POC.Core.Abstractions.Services
{
    public interface ITenantService
    {
        Task<TenantSetting> GetTenantSettingAsync(string tenantId);
    }
}
