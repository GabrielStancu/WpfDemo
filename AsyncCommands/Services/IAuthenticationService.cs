using System.Threading.Tasks;

namespace AsyncCommands.Services;
public interface IAuthenticationService
{
    Task Login(string username);
}

public class AuthenticationService : IAuthenticationService
{
    public async Task Login(string username)
    {
        await Task.Delay(5000);
    }
}
