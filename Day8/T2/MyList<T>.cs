    public class MyList<T>
    {
        private T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;

        public int Count => _count;
        public int Capacity => _items.Length;

        public MyList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                return _items[index];
            }
            set 
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count++] = item;
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_items, item, 0, _count);
            if (index < 0) return false;

            _count--;
            if (index < _count)
            {
                Array.Copy(_items, index + 1, _items, index, _count - index);
            }
            _items[_count] = default(T);
            return true;
        }

        public T Find(Predicate<T> predicate)
        {
            for (int i = 0; i < _count; i++)
            {
                if (predicate(_items[i])) return _items[i];
            }
            return default(T);
        }

        public void Sort(Comparison<T> comparison)
        {
            Array.Sort(_items, 0, _count, Comparer<T>.Create(comparison));
        }
    }
