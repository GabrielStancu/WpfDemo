using System.Collections.ObjectModel;
using EventCommands.Commands;
using System.Windows.Input;
using EventCommands.Models;

namespace EventCommands.ViewModels;
public class TodoListViewModel : BaseViewModel
{
    private ObservableCollection<TodoItem> _todoItems;

    public ObservableCollection<TodoItem> TodoItems
    {
        get => _todoItems;
        set
        {
            _todoItems = value;
            OnPropertyChanged(nameof(TodoItems));
        }
    }

    public ICommand LoadTodoItemsCommand { get; set; }

    public ICommand SelectedTodoItemsChangedCommand { get; set; }

    public TodoListViewModel()
    {
        _todoItems = new ObservableCollection<TodoItem>();
        LoadTodoItemsCommand = new LoadToDoItemsCommand(this);
        SelectedTodoItemsChangedCommand = new SelectedTodoItemsChangedCommand();
    }
}
