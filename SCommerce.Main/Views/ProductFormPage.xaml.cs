using SCommerce.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Views
{
    public sealed partial class ProductFormPage : Page
    {
        public ProductFormPageViewModel ViewModel => (ProductFormPageViewModel)DataContext;

        public ProductFormPage()
        {
            this.InitializeComponent();
        }
    }
}
