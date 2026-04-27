    public class ListManager<T>
    {
        private MyList<T> _storage;

        public ListManager()
        {
            _storage = new MyList<T>();
        }

        public void AddItem(T item) => _storage.Add(item);

        public void RemoveItem(T item) => _storage.Remove(item);

        public void SortItems(Comparison<T> comparison)
        {
            _storage.Sort(comparison);
        }

        public T FindFirstMatch(Predicate<T> criteria)
        {
            return _storage.Find(criteria);
        }

        public void PrintAll()
        {
            for (int i = 0; i < _storage.Count; i++)
            {
                Console.WriteLine(_storage[i]);
            }
        }
    }