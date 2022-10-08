using System.Windows.Input;
using Navigation.Commands;

namespace Navigation.ViewModels;
public class MainViewModel : BaseViewModel
{
    private BaseViewModel _selectedViewModel;
    public BaseViewModel SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            _selectedViewModel = value;
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }

    public ICommand UpdateViewModelCommand { get; set; }

    public MainViewModel()
    {
        UpdateViewModelCommand = new UpdateViewCommand(this);
    }
}
