using DragAndDrop.ViewModels;
using System.Windows;

namespace DragAndDrop.Commands;

public class DeleteRectangleCommand : CommandBase
{
    private readonly CanvasViewModel _canvasViewModel;

    public DeleteRectangleCommand(CanvasViewModel canvasViewModel)
    {
        _canvasViewModel = canvasViewModel;
    }

    public override void Execute(object? parameter)
    {
        MessageBox.Show($"{_canvasViewModel.RemoveRectangleName} was removed.");
    }
}
