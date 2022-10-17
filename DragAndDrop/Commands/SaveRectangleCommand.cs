using DragAndDrop.ViewModels;
using System.Windows;

namespace DragAndDrop.Commands;
public class SaveRectangleCommand : CommandBase
{
    private CanvasViewModel _canvasViewModel;

    public SaveRectangleCommand(CanvasViewModel canvasViewModel)
    {
        _canvasViewModel = canvasViewModel;
    }

    public override void Execute(object? parameter)
    {
        MessageBox.Show($"Successfully saved the rectangle to position ({_canvasViewModel.X}, {_canvasViewModel.Y}).");
    }
}
