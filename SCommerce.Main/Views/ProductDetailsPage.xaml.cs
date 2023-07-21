using SCommerce.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Views
{
    public sealed partial class ProductDetailsPage : Page
    {
        public ProductDetailsPageViewModel ViewModel => (ProductDetailsPageViewModel)this.DataContext;
        
        public ProductDetailsPage()
        {
            this.InitializeComponent();
            this.DataContext = new ProductDetailsPageViewModel();
        }
    }
}
