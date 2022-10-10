using System.Threading.Tasks;
using System.Windows.Input;
using AsyncCommands.Commands;
using AsyncCommands.Services;

namespace AsyncCommands.ViewModels;
public class LoginViewModel : ViewModelBase
{
    private string _username = string.Empty;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    private string _statusMessage = string.Empty;
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasStatusMessage));
        }
    }

    public bool HasStatusMessage => !string.IsNullOrEmpty(StatusMessage);

    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        // Command per class approach
        LoginCommand = new LoginCommand(this,
            new AuthenticationService(),
            (ex) => StatusMessage = ex.Message);

        // // Relay command
        // LoginCommand = new AsyncRelayCommand(Login, (ex) => StatusMessage = ex.Message);
    }

    private async Task Login()
    {
        StatusMessage = "Logging in...";

        await new AuthenticationService().Login(Username);

        StatusMessage = "Successfully logged in";
    }
}
