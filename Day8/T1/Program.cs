class Program
{
    static void Main()
    {
        CommandManager manager = new CommandManager();

        manager.Execute(new Command("Написал текст 'Привет'"));
        manager.Execute(new Command("Изменил шрифт на Bold"));
        manager.Execute(new Command("Удалил абзац"));

        manager.ShowHistory();

        manager.Undo();
        manager.Undo();

        manager.Redo();

        manager.Execute(new Command("Вставил картинку"));

        manager.ShowHistory();
    }
}