using System.Text.Json.Serialization;

namespace FabulousStore.POC.Core.Configurations
{
    public class TenantSettingCollection
    {
        public List<TenantSetting> Settings { get; set; }
    }

    public class TenantSetting
    {
        public string TenantId { get; set; }
                
        public VelocityLimit VelocityLimits { get; set; }

        public Threshold Thresholds { get; set; }

        public CountrySanction CountrySanctions { get; set; }
    }

    public class VelocityLimit
    {
        public int Daily { get; set; }
    }

    public class Threshold
    {
        public int PerTransaction { get; set; }
    }

    public class CountrySanction
    {
        public string SourceCountryCode { get; set; }

        public string DestinationCountryCode { get; set; }
    }
}
