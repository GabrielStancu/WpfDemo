using DragAndDrop.Commands;
using System.Windows.Input;

namespace DragAndDrop.ViewModels;
public class CanvasViewModel : ViewModelBase
{
	private double _x;
	public double X
	{
		get => _x;
		set
		{
			_x = value;
			OnPropertyChanged(nameof(X));
		}
	}

	private double _y;
	public double Y
	{
		get => _y;
		set
		{
			_y = value;
			OnPropertyChanged(nameof(Y));
		}
	}

	private string _removeRectangleName;
	public string RemoveRectangleName
	{
		get => _removeRectangleName;
		set
		{
			_removeRectangleName = value;
			OnPropertyChanged(nameof(RemoveRectangleName));
		}
	}

	public ICommand SaveRectangleCommand { get; }
	public ICommand DeleteRectangleCommand { get; }

    public CanvasViewModel()
	{
		SaveRectangleCommand = new SaveRectangleCommand(this);
		DeleteRectangleCommand = new DeleteRectangleCommand(this);
    }
}
