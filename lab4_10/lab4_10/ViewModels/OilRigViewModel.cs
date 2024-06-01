using lab4_10.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace lab4_10.ViewModels
{
    public class OilRigViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int OilExtract { get; private set; }
        public string StatusOil { get; private set; }

        private int _id;
        private OilRig _oilRig;
        private Dispatcher _dispatcher;

        public OilRigViewModel(int id, Dispatcher dispatcher)
        {
            this._dispatcher = dispatcher;
            Id = id;
            _oilRig = new OilRig();
            _oilRig._oilExtracted += (sender, e) =>
            {
                dispatcher.Invoke(() => OilExtract = _oilRig.getOilExtract());
                OnPropertyChanged(nameof(OilExtract));
            };

            _oilRig._statusChanged += (sender, newStatus) =>
            {
                dispatcher.Invoke(() => StatusOil = newStatus.ToString());
                OnPropertyChanged(nameof(StatusOil));
            };

            Task.Run(() => _oilRig.StartDrilling());
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
