using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
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

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            Status = e.Parameter.ToString();
        }
    }
}
