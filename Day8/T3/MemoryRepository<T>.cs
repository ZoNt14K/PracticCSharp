using System.Collections.Generic;

    public class MemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }
    }
