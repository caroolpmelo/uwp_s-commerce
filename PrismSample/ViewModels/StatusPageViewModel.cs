using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.Services;
using System.Collections.Generic;

namespace PrismSample.ViewModels
{
    public class StatusPageViewModel : ViewModelBase
    {
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

        public StatusPageViewModel(ICounterService counterService)
        {
            Counter = counterService.GetCount();
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            Status = e.Parameter.ToString();
        }
    }
}
