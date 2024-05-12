using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Lab_3.ViewModels;

namespace Lab_3.Views;

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
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }
        points.Text = _mainWindowViewModel.PointerMsg(point: point);
    }

    private void ClearHandler(object? sender, RoutedEventArgs e)
    {
        _mainWindowViewModel.ClearPoints();
        points.Text = "Точки: [ ]";
        _mainWindowViewModel.Type = "";
        characteristics.Text = "Информация о фигуре";
    }

    private void Draw(object? sender, RoutedEventArgs e)
    {
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }
        
        if (_mainWindowViewModel.Type == "Lab_2.Models.Ellipse")
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
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = "Lab_2.Models.Point";
        characteristics.Text = "Выбрана Точка";
    }

    private void SplitButtonLine(object? sender, RoutedEventArgs e)
    {
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }        
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = "Lab_2.Models.Line";
        characteristics.Text = "Выбрана Линия";
    }

    private void SplitButtonPolygon(object? sender, RoutedEventArgs e)
    {
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }        
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = "Lab_2.Models.Polygon";
        characteristics.Text = "Выбран Многоугольник";

    }

    private void SplitButtonEllipse(object? sender, RoutedEventArgs e)
    {
        if (_mainWindowViewModel.Route.Length == 0)
        {
            characteristics.Text = "Загрузите dll!";
            return;
        }
        ClearHandler(sender, e);
        _mainWindowViewModel.Type = "Lab_2.Models.Ellipse";
        characteristics.Text = "Выбран Эллипс";

    }

    private async void OpenFile(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        if (files.Count >= 1)
        {
            var path = files[0].Path;
            _mainWindowViewModel.Route = path.AbsolutePath;
            Console.WriteLine(_mainWindowViewModel.Route);
        }
    }
}