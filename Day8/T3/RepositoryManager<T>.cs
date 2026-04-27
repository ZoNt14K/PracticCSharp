using System.Collections.Generic;

    public class RepositoryManager<T>
    {
        private readonly IRepository<T> _repository;

        public RepositoryManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void DisplayAll()
        {
            Console.WriteLine($"--- Содержимое репозитория ({typeof(T).Name}) ---");
            foreach (var item in _repository.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        public T Find(Func<T, bool> predicate)
        {
            foreach (var item in _repository.GetAll())
            {
                if (predicate(item)) return item;
            }
            return default(T);
        }

        public void Add(T item) => _repository.Add(item);
        public void Remove(T item) => _repository.Remove(item);
    }