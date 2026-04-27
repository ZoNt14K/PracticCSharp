using System;
using System.Collections;

    public class CommandManager
    {
        private Stack _undoStack;
        private Stack _redoStack;

        public CommandManager()
        {
            _undoStack = new Stack();
            _redoStack = new Stack();
        }

        public void Execute(Command command)
        {
            _undoStack.Push(command);
            _redoStack.Clear();
            Console.WriteLine($"Выполнено: {command.Description}");
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                Command cmd = (Command)_undoStack.Pop();
                _redoStack.Push(cmd);
                Console.WriteLine($"Отменено: {cmd.Description}");
            }
            else
            {
                Console.WriteLine("Нет действий для отмены.");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                Command cmd = (Command)_redoStack.Pop();
                _undoStack.Push(cmd);
                Console.WriteLine($"Восстановлено: {cmd.Description}");
            }
            else
            {
                Console.WriteLine("Нет действий для восстановления.");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("\n--- Текущая история (Undo Stack) ---");
            foreach (var item in _undoStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------\n");
        }
    }
