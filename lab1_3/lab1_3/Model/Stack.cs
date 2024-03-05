namespace lab1_3
{
    public class Stack<T>
    {
        #region Fields
        const Int32 N = 10;

        private T[] _items;
        private Int32 _count;
        #endregion

        #region Constructors
        public Stack()
        {
            _items = new T[N];
        }

        public Stack(Int32 length)
        {
            _items = new T[length];
        }
        #endregion

        #region Realization
        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length + 10);
            }
            _items[_count++] = item;
        }

        public T Pop()
        {
            T item = _items[--_count];
            _items[_count] = default(T);

            if (_count > 0 && _count < _items.Length - 10)
            {
                Resize(_items.Length - 10);
            }

            return item;
        }

        public void Clear()
        {
            _count = 0;
            Array.Clear(_items, 0, _count);
        }

        private void Resize(Int32 max)
        {
            T[] tempItems = new T[max];
            for (Int32 i = 0; i < _count; i++)
            {
                tempItems[i] = _items[i];
            }
            _items = tempItems;
        }

        public bool IsEmpty
        {
            get => _count == 0;
        }
        public int Count
        {
            get => _count;
        }
        #endregion
    }
}
