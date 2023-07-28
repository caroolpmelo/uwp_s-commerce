using PrismSample.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PrismSample.Views
{
    public sealed partial class StatusPage : Page
    {
        public StatusPageViewModel ViewModel => (StatusPageViewModel)DataContext;

        public StatusPage()
        {
            this.InitializeComponent();
        }
    }
}
