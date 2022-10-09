using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using EventCommands.Models;
using EventCommands.ViewModels;

namespace EventCommands.Commands;
public class LoadToDoItemsCommand : ICommand
{
    private readonly TodoListViewModel _todoListViewModel;

    public LoadToDoItemsCommand(TodoListViewModel todoListViewModel)
    {
        _todoListViewModel = todoListViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        // Get list items from API
        var todoItems = await GetTodoItemsAsync();

        // Set the items on the view models
        _todoListViewModel.TodoItems = new ObservableCollection<TodoItem>(todoItems);
    }

    public event EventHandler? CanExecuteChanged;

    public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
    {
        return await Task.FromResult(new[]
        {
            new TodoItem()
            {
                Description = "Walk the dog.",
                IsCompleted = false,
                OwnerName = "John"
            },
            new TodoItem()
            {
                Description = "Take out the trash.",
                IsCompleted = false,
                OwnerName = "Mary"
            },
            new TodoItem()
            {
                Description = "Upload YouTube video.",
                IsCompleted = true,
                OwnerName = "SingletonSean"
            }
        });
    }
}
