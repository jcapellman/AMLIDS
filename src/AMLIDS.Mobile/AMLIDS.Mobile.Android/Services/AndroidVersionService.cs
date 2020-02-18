using AMLIDS.lib.common.Models;
using AMLIDS.Mobile.Services;

using Android.Content.PM;

using Xamarin.Essentials;

namespace AMLIDS.Mobile.Droid.Services
{
    public class AndroidVersionService : IVersionService
    {
        readonly PackageInfo _appInfo;

        public AndroidVersionService()
        {
            var context = Android.App.Application.Context;

            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }

        public string VersionNumber => _appInfo.VersionName;

        public string BuildNumber => _appInfo.VersionCode.ToString();

        DeviceInformationItem IVersionService.DeviceInfo => new DeviceInformationItem
        {
            Model = DeviceInfo.Model,
            Manufacturer = DeviceInfo.Manufacturer,
            PlatformType = DeviceInfo.Platform.ToString(),
            PlatformVersion = DeviceInfo.VersionString
        };
    }
}