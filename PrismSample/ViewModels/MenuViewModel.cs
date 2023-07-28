using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Utils;

namespace PrismSample.ViewModels
{
    public class MenuViewModel :ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MenuViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void NavigateWelcome()
        {
            navigationService.Navigate(PageTokens.WELCOME, "Welcome");
        }

        public void NavigateSuccess()
        {
            navigationService.Navigate(PageTokens.STATUS, "Success");
        }

        public void NavigateFail()
        {
            navigationService.Navigate(PageTokens.STATUS, "Fail");
        }
    }
}
