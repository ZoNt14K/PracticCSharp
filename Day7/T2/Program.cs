using System;
using System.IO;

namespace ExceptionChainingDemo
{
    public class CustomFileException : Exception
    {
        public CustomFileException(string message) : base(message) { }

        public CustomFileException(string message, Exception innerException) 
            : base(message, innerException) { }
    }

    public class FileReader
    {
        public void ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Системная ошибка: Файл по пути '{path}' не найден.");
            }
            
            string content = File.ReadAllText(path);
            Console.WriteLine("Файл успешно прочитан.");
        }
    }

    public class FileProcessor
    {
        private readonly FileReader _reader = new FileReader();

        public void ProcessData(string filePath)
        {
            try
            {
                _reader.ReadFile(filePath);
            }
            catch (FileNotFoundException ex)
            {
                throw new CustomFileException("Произошла ошибка при обработке данных файла в модуле FileProcessor.", ex);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor processor = new FileProcessor();
            string path = "non_existent_file.txt";

            try
            {
                processor.ProcessData(path);
            }
            catch (CustomFileException ex)
            {
                Console.WriteLine("=== ЛОГИРОВАНИЕ ИСКЛЮЧЕНИЯ ===");

                Console.WriteLine($"Сообщение: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("\n--- Внутреннее исключение (Первопричина) ---");
                    Console.WriteLine($"Тип: {ex.InnerException.GetType().Name}");
                    Console.WriteLine($"Сообщение: {ex.InnerException.Message}");
                }

                Console.WriteLine("\n--- Стек вызовов (StackTrace) ---");
                Console.WriteLine(ex.StackTrace);
                
                Console.WriteLine("\n==============================");
            }
            
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}