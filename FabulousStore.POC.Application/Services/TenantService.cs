using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.Configurations;
using Microsoft.Extensions.Options;

namespace FabulousStore.POC.Core.Services
{
    internal class TenantService(IOptions<TenantSettingCollection> options) : ITenantService
    {
        private readonly List<TenantSetting> tenantSettings = options.Value.Settings;

        //Fetch from DB or Config
        public async Task<TenantSetting> GetTenantSettingAsync(string tenantId) => tenantSettings.FirstOrDefault(t => t.TenantId.Equals(tenantId, StringComparison.OrdinalIgnoreCase));
    }
}
