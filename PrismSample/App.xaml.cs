using Prism.Unity.Windows;
using PrismSample.Utils;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace PrismSample
{
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.WELCOME, null);

            return Task.CompletedTask;
        }
    }
}
