using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DragAndDrop.Views;
/// <summary>
/// Interaction logic for CanvasView.xaml
/// </summary>
public partial class Canvas : UserControl
{
    public static readonly DependencyProperty IsChildHitTestVisibleProperty = 
        DependencyProperty.Register(nameof(IsChildHitTestVisible), typeof(bool), typeof(Canvas), new PropertyMetadata(true));

    public bool IsChildHitTestVisible
    {
        get => (bool)GetValue(IsChildHitTestVisibleProperty);
        set => SetValue(IsChildHitTestVisibleProperty, value);
    }

    public static readonly DependencyProperty ColorProperty =
        DependencyProperty.Register(nameof(Color), typeof(Brush), typeof(Canvas), new PropertyMetadata(Brushes.Black));

    public Brush Color
    {
        get => (Brush)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public static readonly DependencyProperty RectangleDropCommandProperty =
        DependencyProperty.Register(nameof(RectangleDropCommand), typeof(ICommand), typeof(Canvas), new PropertyMetadata(null));

    public ICommand RectangleDropCommand
    {
        get => (ICommand)GetValue(RectangleDropCommandProperty);
        set => SetValue(RectangleDropCommandProperty, value);
    }

    public static readonly DependencyProperty RectangleRemoveCommandProperty =
        DependencyProperty.Register(nameof(RectangleRemoveCommand), typeof(ICommand), typeof(Canvas), new PropertyMetadata(null));
    public ICommand RectangleRemoveCommand
    {
        get => (ICommand)GetValue(RectangleRemoveCommandProperty);
        set => SetValue(RectangleRemoveCommandProperty, value);
    }

    public static readonly DependencyProperty RemoveRectangleNameProperty =
        DependencyProperty.Register(nameof(RemoveRectangleName), typeof(string), typeof(Canvas), 
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public string RemoveRectangleName
    {
        get => (string)GetValue(RemoveRectangleNameProperty);
        set => SetValue(RemoveRectangleNameProperty, value);
    }

    public Canvas()
    {
        InitializeComponent();
    }

    private void Rectangle_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed) 
            return;

        IsChildHitTestVisible = false;
        DragDrop.DoDragDrop(Rectangle, new DataObject(DataFormats.Serializable, Rectangle), DragDropEffects.Move);
        IsChildHitTestVisible = true;
    }

    private void Canvas_DragOver(object sender, DragEventArgs e)
    {
        var data = e.Data.GetData(DataFormats.Serializable);

        if (data is not UIElement element)
            return;

        var dropPosition = e.GetPosition(DragCanvas);

        System.Windows.Controls.Canvas.SetLeft(element, dropPosition.X);
        System.Windows.Controls.Canvas.SetTop(element, dropPosition.Y);

        if (DragCanvas.Children.Contains(element))
            return;

        DragCanvas.Children.Add(element);
    }

    private void Canvas_DragLeave(object sender, DragEventArgs e)
    {
        if (!e.OriginalSource.Equals(DragCanvas))
            return;

        object? data = e.Data.GetData(DataFormats.Serializable);

        if (data is FrameworkElement element)
        {
            DragCanvas.Children.Remove(element);
            RemoveRectangleName = element.Name;
            RectangleRemoveCommand?.Execute(null);
        }
    }

    private void Canvas_Drop(object sender, DragEventArgs e)
    {
        RectangleDropCommand?.Execute(null);
    }
}
