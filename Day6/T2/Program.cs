using System;

namespace DelegateParameters
{
    public delegate void StringProcessor(string text);

    public class StringActionProvider
    {
        public void ToUpperCase(string input)
        {
            Console.WriteLine($"В верхнем регистре: {input.ToUpper()}");
        }

        public void ToLowerCase(string input)
        {
            Console.WriteLine($"В нижнем регистре: {input.ToLower()}");
        }
    }

    public class ProcessorManager
    {
        public void ProcessString(string str, StringProcessor processor)
        {
            Console.WriteLine($"Принята строка для обработки: \"{str}\"");

            processor(str); 
            
            Console.WriteLine("Обработка завершена.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StringActionProvider actions = new StringActionProvider();
            ProcessorManager manager = new ProcessorManager();

            string testData = "Hello, Delegate World!";

            manager.ProcessString(testData, actions.ToUpperCase);

            manager.ProcessString(testData, actions.ToLowerCase);
            
            Console.ReadKey();
        }
    }
};