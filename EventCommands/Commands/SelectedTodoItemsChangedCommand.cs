using System;
using System.Collections.Generic;
using System.Windows.Input;
using EventCommands.Models;

namespace EventCommands.Commands;
public class SelectedTodoItemsChangedCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var items = parameter as IEnumerable<TodoItem>;
        // from here do whatever you want with it
    }

    public event EventHandler? CanExecuteChanged;
}
