class Program
{
    static void Main()
    {
        AudioDevice myDevice = new AudioDevice();

        Console.WriteLine("=== Управление аудиоустройством ===");

        ISpeaker speakerLink = myDevice; 
        speakerLink.AdjustVolume(70);

        IMicrophone micLink = myDevice;
        micLink.AdjustVolume(30);

        ((ISpeaker)myDevice).AdjustVolume(100);
        ((IMicrophone)myDevice).AdjustVolume(0);
        
        Console.WriteLine("\nГотово: Настройки применены раздельно.");
    }
}