using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace AMLIDS.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/jcapellman/AMLIDS/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}