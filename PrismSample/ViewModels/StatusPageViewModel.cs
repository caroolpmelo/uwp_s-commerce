using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Events;
using PrismSample.Services;
using System;
using System.Collections.Generic;

namespace PrismSample.ViewModels
{
    public class StatusPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigationService;

        private string status = "None";
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        private int counter;

        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }

        public StatusPageViewModel(ICounterService counterService,
            IEventAggregator eventAggregator, INavigationService navigationService)
        {
            Counter = counterService.GetCount();
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            Status = e.Parameter.ToString();

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

        private void OnAuthChanged(bool state)
        {
            if (!state)
            {
                if (navigationService.CanGoBack())
                {
                    navigationService.GoBack();
                }
            }
        }
    }
}
