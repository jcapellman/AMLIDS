using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using AMLIDS.lib.dal.litedb;
using AMLIDS.lib.dal;
using AMLIDS.Mobile.Droid.Services;

namespace AMLIDS.Mobile.Droid
{
    [Activity(Label = "AMLIDS", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Xamarin.Forms.DependencyService.Register<LiteDBDataStorage>();
            Xamarin.Forms.DependencyService.Register<AndroidVersionService>();
            Xamarin.Forms.DependencyService.Register<AndroidNetworkService>();

            Xamarin.Forms.DependencyService.Get<IDataStorage>().SetPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}