using System;

class Program
{
    static void TimeToHMS(int T, out int H, out int M, out int S)
    {
        H = T / 3600;
        M = (T % 3600) / 60;
        S = T % 60;
    }

    static void Main()
    {
        int[] timeIntervals = { 400, 3661, 7200, 10000, 86400 };

        Console.WriteLine($"{"Секунды (T)",-12} | {"Часы (H)",-8} | {"Минуты (M)",-10} | {"Секунды (S)",-8}");
        Console.WriteLine(new string('-', 50));

        foreach (int t in timeIntervals)
        {
            int hours, minutes, seconds;

            TimeToHMS(t, out hours, out minutes, out seconds);

            Console.WriteLine($"{t,-12} | {hours,-8} | {minutes,-10} | {seconds,-8}");
        }
    }
}