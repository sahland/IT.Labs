using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;

namespace lab4_10.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<OilRigViewModel> OilRigs
        {
            get { return _oilRigs; }
            set
            {
                _oilRigs = value;
                OnPropertyChanged(nameof(OilRigs));
            }
        }

        private ObservableCollection<OilRigViewModel> _oilRigs;
        private Dispatcher _dispatcher;
        private int _numberOilRig;

        public MainViewModel(Dispatcher dispatcher)
        {
            _numberOilRig = 0;

            this._dispatcher = dispatcher;
            OilRigs = new ObservableCollection<OilRigViewModel>();
        }

        public async Task InitializeOilRigsAsync()
        {
            await Task.Delay(100);
            OilRigs.Add(new OilRigViewModel(_numberOilRig, _dispatcher));
            _numberOilRig++;

            OnPropertyChanged(nameof(_numberOilRig));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
