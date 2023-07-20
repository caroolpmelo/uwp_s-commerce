using SCommerce.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Views
{
    public sealed partial class ProductDetailsPage : Page
    {
        public ProductDetailsPageViewModel ViewModel => new ProductDetailsPageViewModel();
        public ProductDetailsPage()
        {
            this.InitializeComponent();
        }
    }
}
