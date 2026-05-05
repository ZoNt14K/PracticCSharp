using System;

class Program
{
    static void Main(string[] args)
    {
        Light livingRoomLight = new Light();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        RemoteControl remote = new RemoteControl();

        Console.WriteLine("--- Программируем пульт на ВКЛЮЧЕНИЕ ---");
        remote.SetCommand(lightOn);
        remote.PressButton();

        Console.WriteLine("\n--- Программируем пульт на ВЫКЛЮЧЕНИЕ ---");
        remote.SetCommand(lightOff);
        remote.PressButton();
    }
}