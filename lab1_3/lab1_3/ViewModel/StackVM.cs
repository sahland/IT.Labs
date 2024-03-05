using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace lab1_3.ViewModel
{
    public class StackVM<T> : INotifyPropertyChanged
    {
        #region Commands
        public Action PushCommand { get; private set; }
        public Action PopCommand { get; private set; }
        public Action ClearCommand { get; private set; }
        #endregion

        #region Fields
        private readonly Stack<T> _stack;

        public ObservableCollection<T> items { get; private set; }
        public Int32 count => _stack.Count;
        public Boolean isEmpty => _stack.IsEmpty;

        public string NewItem;

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructors
        public StackVM()
        {
            _stack = new Stack<T>();
            items = new ObservableCollection<T>();
            PushCommand = () => Push();
            PopCommand = () => Pop();
            ClearCommand = () => Clear();

            NewItem = "";

        }
        #endregion

        #region Realization
        private void Push()
        {
            if (!string.IsNullOrEmpty(NewItem))
            {
                _stack.Push((T)Convert.ChangeType(NewItem, typeof(T)));
                items.Add((T)Convert.ChangeType(NewItem, typeof(T)));
                OnPropertyChanged(nameof(items));
                OnPropertyChanged(nameof(count));
            }
        }

        private bool CanPush(object parameter) => true;

        private void Pop() {
            if (_stack.IsEmpty)
            {
                MessageBox.Show("STACK IS EMPTY!");
                return;
            }

            _stack.Pop();
            items.RemoveAt(items.Count - 1);
            OnPropertyChanged(nameof(items));
            OnPropertyChanged(nameof(count));
        }

        private bool CanPop() => !_stack.IsEmpty;

        private void Clear()
        {
            _stack.Clear();
            items.Clear();
            OnPropertyChanged(nameof(items));
            OnPropertyChanged(nameof(count));
        }

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
