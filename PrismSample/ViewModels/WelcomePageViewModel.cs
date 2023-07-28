using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Services;

namespace PrismSample.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly ICounterService counterService;

        private int counter;
        public int Counter
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

        public WelcomePageViewModel(INavigationService navigationService, ICounterService counterService)
        {
            this.navigationService = navigationService;
            this.counterService = counterService;

            Counter = counterService.GetCount();

            AddCountCommand = new DelegateCommand(AddCount, CanAddCount)
                .ObservesProperty(() => IncrementAmount);
        }

        private void AddCount()
        {
            var value = int.Parse(IncrementAmount);
            Counter = counterService.IncrementCount(value);
        }

        private bool CanAddCount()
        {
            return int.TryParse(IncrementAmount, out int _);
        }

        public void Increment()
        {
            Counter = counterService.IncrementCount(1);
        }
    }
}
