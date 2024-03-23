using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Xml.Linq;

namespace lab2_5.ViewModels
{
    public abstract class BaseFigureVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private bool _isSelected;

        protected BaseFigureVM(string name)
        {
            Name = name;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Draw(Canvas canvas);

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
