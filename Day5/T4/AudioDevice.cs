    public class AudioDevice : ISpeaker, IMicrophone
    {
        void ISpeaker.AdjustVolume(int level)
        {
            Console.WriteLine($"[Динамик]: Громкость воспроизведения установлена на {level}%.");
        }

        void IMicrophone.AdjustVolume(int level)
        {
            Console.WriteLine($"[Микрофон]: Чувствительность записи установлена на {level}%.");
        }
    }