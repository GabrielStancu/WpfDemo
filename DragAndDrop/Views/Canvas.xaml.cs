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

        if (data is UIElement element)
        {
            DragCanvas.Children.Remove(element);
        }
    }
}
