using System.Collections.Generic;

    public interface IRepository<T>
    {
        void Add(T item);
        bool Remove(T item);
        IEnumerable<T> GetAll();
    }
