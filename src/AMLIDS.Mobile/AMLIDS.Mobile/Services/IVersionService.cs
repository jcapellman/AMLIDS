using AMLIDS.lib.common.Models;

namespace AMLIDS.Mobile.Services
{
    public interface IVersionService
    {
        string VersionNumber { get; }

        string BuildNumber { get; }

        DeviceInformationItem DeviceInfo { get; }
    }
}