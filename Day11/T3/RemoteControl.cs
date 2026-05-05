public class RemoteControl
{
    private ICommand _command;

    // Установка команды (например, программирование кнопки пульта)
    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    // Нажатие кнопки
    public void PressButton()
    {
        if (_command != null)
        {
            _command.Execute();
        }
    }
}