using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Lab_2.Models;
using Lab_2.ViewModels;

namespace Lab_2.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    public MainWindow()
    {
        InitializeComponent();
        _mainWindowViewModel = new MainWindowViewModel();
    }
    
    private void PointerPressedHandler (object sender, PointerPressedEventArgs args)
    {
        var point = args.GetCurrentPoint(this);
        points.Text = _mainWindowViewModel.PointerMsg(point: point);
    }

    private void ClearHandler(object? sender, RoutedEventArgs e)
    {
        _mainWindowViewModel.ClearPoints();
        points.Text = "Точки: [ ]";
        _mainWindowViewModel.Type = ShapeType.Shape;
        characteristics.Text = "Информация о фигуре";
    }

    private void Draw(object? sender, RoutedEventArgs e)
    {
        if (_mainWindowViewModel.Type == ShapeType.Ellipse)
        {
            if (RadiusB.Text != null && RadiusA.Text != null && (RadiusA.Text.Length == 0 || RadiusB.Text.Length == 0))
            {
                characteristics.Text = "Не задан радиус!";
            }
            else
            {
                double.TryParse(RadiusA.Text, out var a);
                double.TryParse(RadiusB.Text, out var b);
                _mainWindowViewModel.RadiusA = a;
                _mainWindowViewModel.RadiusB = b;
            }
        }
        characteristics.Text = _mainWindowViewModel.Characteristics();
    }

    private void SplitButtonPoint(object? sender, RoutedEventArgs e)
    {
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = ShapeType.Point;
        characteristics.Text = "Выбрана Точка";
    }

    private void SplitButtonLine(object? sender, RoutedEventArgs e)
    {
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = ShapeType.Line;
        characteristics.Text = "Выбрана Линия";
    }

    private void SplitButtonPolygon(object? sender, RoutedEventArgs e)
    {
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = ShapeType.Polygon;
        characteristics.Text = "Выбран Многоугольник";

    }

    private void SplitButtonEllipse(object? sender, RoutedEventArgs e)
    {
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = ShapeType.Ellipse;
        characteristics.Text = "Выбран Эллипс";

    }
}