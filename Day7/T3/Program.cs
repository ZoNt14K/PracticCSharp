using System;

namespace RegistrationSystem
{
    public class AgeRestrictionException : Exception
    {
        public int AttemptedAge { get; }

        public AgeRestrictionException() : base("Регистрация отклонена: пользователь слишком молод.") { }

        public AgeRestrictionException(string message) : base(message) { }

        public AgeRestrictionException(string message, int age) : base(message)
        {
            AttemptedAge = age;
        }
    }

    public class UserRegistration
    {
        private const int MinimumAge = 18;

        public void RegisterUser(string userName, int age)
        {
            Console.WriteLine($"Попытка регистрации пользователя: {userName}...");

            if (age < MinimumAge)
            {
                throw new AgeRestrictionException(
                    $"Ошибка регистрации: пользователю '{userName}' всего {age} лет. " +
                    $"Минимально допустимый возраст: {MinimumAge}.", age);
            }

            Console.WriteLine($"Пользователь '{userName}' успешно зарегистрирован!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserRegistration registrationService = new UserRegistration();

            var usersToRegister = new (string Name, int Age)[]
            {
                ("Алексей", 25),
                ("Мария", 16),
                ("Иван", 19)
            };

            foreach (var user in usersToRegister)
            {
                try
                {
                    registrationService.RegisterUser(user.Name, user.Age);
                }
                catch (AgeRestrictionException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ОТКАЗ: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла системная ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("Работа программы завершена.");
        }
    }
}