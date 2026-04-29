class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("Запуск приложения.");
        logger1.Log("Пользователь авторизовался.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Выполнение сложной операции...");
        logger2.Log("Операция завершена успешно.");

        logger1.ShowLogs();

        if (ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("\n[Успех] Оба объекта ссылаются на один и тот же экземпляр Singleton.");
        }
    }
}