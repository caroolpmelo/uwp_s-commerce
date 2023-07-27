using Prism.Windows.Mvvm;

namespace PrismSample.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private int counter = 0;
        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }
    }
}
