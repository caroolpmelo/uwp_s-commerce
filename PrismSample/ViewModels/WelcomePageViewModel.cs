using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Events;
using PrismSample.Services;
using System.Collections.Generic;

namespace PrismSample.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly ICounterService counterService;
        private readonly EventAggregator eventAggregator;

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

        private bool loggedIn;
        public bool LoggedIn
        {
            get { return loggedIn; }
            set { SetProperty(ref loggedIn, value); }
        }

        public DelegateCommand AddCountCommand { get; set; }

        public WelcomePageViewModel(INavigationService navigationService,
            ICounterService counterService, EventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.counterService = counterService;
            this.eventAggregator = eventAggregator;

            Counter = counterService.GetCount();

            AddCountCommand = new DelegateCommand(AddCount, CanAddCount)
                .ObservesProperty(() => IncrementAmount);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var authChangedEvent = eventAggregator.GetEvent<AuthChangedEvent>();
            if (!authChangedEvent.Contains(OnAuthChanged))
            {
                authChangedEvent.Subscribe(OnAuthChanged);
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            var authChangedEvent = eventAggregator.GetEvent<AuthChangedEvent>();
            if (authChangedEvent.Contains(OnAuthChanged))
            {
                authChangedEvent.Unsubscribe(OnAuthChanged);
            }
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

        public void OnAuthChanged(bool state)
        {
            LoggedIn = state;
        }
    }
}
