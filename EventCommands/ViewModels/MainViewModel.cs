namespace EventCommands.ViewModels;
public class MainViewModel : BaseViewModel
{
    private TodoListViewModel _todoListViewModel;
    public TodoListViewModel TodoListViewModel
    {
        get => _todoListViewModel;
        set
        {
            _todoListViewModel = value;
            OnPropertyChanged(nameof(TodoListViewModel));
        }
    }

    public MainViewModel()
    {
        TodoListViewModel = new TodoListViewModel();
    }
}
