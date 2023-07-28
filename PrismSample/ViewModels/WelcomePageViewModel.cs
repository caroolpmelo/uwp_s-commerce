using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Models;
using PrismSample.Utils;
using System;

namespace PrismSample.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private CountValue counter = new CountValue();
        public CountValue Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }

        private string incrementAmount;

        public string IncrementAmount
        {
            get { return incrementAmount; }
            set { SetProperty(ref incrementAmount, value); }
        }

        public DelegateCommand AddCountCommand { get; set; }

        public WelcomePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            AddCountCommand = new DelegateCommand(AddCount, CanAddCount)
                .ObservesProperty(() => IncrementAmount);
        }

        private void AddCount()
        {
            Counter.Val += int.Parse(IncrementAmount);
            Counter.LastModified = DateTime.Now;
        }

        private bool CanAddCount()
        {
            return int.TryParse(IncrementAmount, out int _);
        }

        public void Increment()
        {
            Counter.Val++;
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
