using System;
using System.Collections.Generic;

public class Logger
{
    private static Logger _instance;

    private List<string> _logs;

    private Logger()
    {
        _logs = new List<string>();
        Console.WriteLine("[System] Инициализация нового логгера.");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void Log(string message)
    {
        string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}";
        _logs.Add(logEntry);
    }

    public void ShowLogs()
    {
        Console.WriteLine("\n--- Список всех логов ---");
        foreach (var log in _logs)
        {
            Console.WriteLine(log);
        }
    }
}