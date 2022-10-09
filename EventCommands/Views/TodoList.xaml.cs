using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventCommands.Views;
/// <summary>
/// Interaction logic for TodoList.xaml
/// </summary>
public partial class TodoList : UserControl
{
    public TodoList()
    {
        InitializeComponent();
    }

    public ICommand LoadCommand
    {
        get => GetValue(LoadCommandProperty) as ICommand;
        set => SetValue(LoadCommandProperty, value);
    }

    public static readonly DependencyProperty LoadCommandProperty = 
        DependencyProperty.Register(nameof(LoadCommand), typeof(ICommand), typeof(TodoList), new PropertyMetadata(null));

    public ICommand SelectedTodoItemsChangedCommand
    {
        get => GetValue(SelectedTodoItemsChangedCommandProperty) as ICommand;
        set => SetValue(SelectedTodoItemsChangedCommandProperty, value);
    }

    public static readonly DependencyProperty SelectedTodoItemsChangedCommandProperty =
        DependencyProperty.Register(nameof(SelectedTodoItemsChangedCommand), typeof(ICommand), typeof(TodoList), new PropertyMetadata(null));

    private void TodoList_OnLoaded(object sender, RoutedEventArgs e)
    {
        LoadCommand?.Execute(null);
    }

    private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SelectedTodoItemsChangedCommand?.Execute(lvTodoItems.SelectedItems);
    }
}
