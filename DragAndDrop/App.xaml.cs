using DragAndDrop.ViewModels;
using System.Windows;

namespace DragAndDrop;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow
        {
            DataContext = new CanvasViewModel()
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}
