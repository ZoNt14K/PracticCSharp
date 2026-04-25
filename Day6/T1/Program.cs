using System;

namespace DelegateExample
{
    public delegate void MessageHandler(string message);

    public class ConsoleLogger
    {
        public void SendToConsole(string msg)
        {
            Console.WriteLine($"[Console Logger]: {msg}");
        }
    }

    public class FileLogger
    {
        public void SaveToFile(string msg)
        {
            Console.WriteLine($"[File Logger]: Сообщение \"{msg}\" успешно сохранено в log.txt");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            FileLogger fileLogger = new FileLogger();

            Console.WriteLine("--- Работа с одиночными методами ---");

            MessageHandler handler = consoleLogger.SendToConsole;
            handler("Привет, это первое сообщение!");

            handler = fileLogger.SaveToFile;
            handler("Важные данные для записи.");

            Console.WriteLine("\n--- Работа с цепочкой вызовов (Multicast) ---");

            MessageHandler multiHandler = consoleLogger.SendToConsole;
            multiHandler += fileLogger.SaveToFile;

            multiHandler("Системное уведомление для всех логгеров.");

            Console.ReadKey();
        }
    }
}