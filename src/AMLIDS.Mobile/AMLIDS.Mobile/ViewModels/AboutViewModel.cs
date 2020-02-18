using System.Windows.Input;

using AMLIDS.Mobile.Services;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace AMLIDS.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _versionString;

        public string VersionString
        {
            get => _versionString;

            set
            {
                _versionString = value;

                OnPropertyChanged();
            }
        }

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/jcapellman/AMLIDS/"));

            VersionString = $"Version {DependencyService.Get<IVersionService>().VersionNumber} (BUILD {DependencyService.Get<IVersionService>().BuildNumber})";
        }

        public ICommand OpenWebCommand { get; }
    }
}