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

        public string PlatformVersion => DeviceInfo.VersionString;

        public string ModelName => DeviceInfo.Model;

        public string Manufacturer => DeviceInfo.Manufacturer;

        public string Platform => DeviceInfo.Platform.ToString();
    }
}