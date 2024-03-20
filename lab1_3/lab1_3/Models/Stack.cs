using lab1_3.Models;

namespace lab1_3
{
    public class Stack : IStack
    {
        #region Fields
        const Int32 N = 10;

        private List<String> _items;
        private Int32 _count;
        #endregion

        #region Constructors
        public Stack()
        {
            _items = new List<String>();
        }
        #endregion

        #region Realization
        public void Push(String item)
        {
            if (_items.Contains(item))
            {
                return;
            }

            _items.Add(item);
        }

        public String Pop()
        {
            if (_count == 0)
            {
                return "";
            }

            String item = _items[_count - 1];
            _items.Remove(item);
            --_count;
            return item;
        }

        public void Clear()
        {
            _count = 0;
            _items.Clear();
        }
        #endregion

        #region Properties
        public Boolean IsEmpty
        {
            get => _count == 0;
        }

        public Int32 Count
        {
            get => _count;
        }
        #endregion
    }
}
