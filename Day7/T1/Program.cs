using System;

namespace ExceptionHandlingDemo
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException() : base("Возраст должен быть не менее 18 лет.") { }

        public InvalidAgeException(string message) : base(message) { }
        
        public InvalidAgeException(string message, Exception innerException) 
            : base(message, innerException) { }
    }

    public class UserAgeValidator
    {
        public void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException($"Доступ запрещен. Возраст {age} меньше 18 лет.");
            }
            
            Console.WriteLine("Возраст успешно прошел проверку. Доступ разрешен.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserAgeValidator validator = new UserAgeValidator();

            Console.WriteLine("--- Тестирование корректного возраста ---");
            try
            {
                validator.ValidateAge(25);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- Тестирование некорректного возраста ---");
            try
            {
                validator.ValidateAge(15);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Поймано исключение!");
                Console.WriteLine($"Сообщение: {ex.Message}");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Внутреннее исключение: {ex.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПрограмма завершила работу.");
        }
    }
}