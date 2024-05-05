using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Input;
using Lab_2.Models;

namespace Lab_2.ViewModels;

public class MainWindowViewModel
{
    private HashSet<Point> _points;
    private ShapeType _type;

    private double _radiusA;
    private double _radiusB;

    public ShapeType Type
    {
        get => _type;
        set => _type = value;
    }
    
    public double RadiusA
    {
        get => _radiusA;
        set => _radiusA = value;
    }
    
    public double RadiusB
    {
        get => _radiusB;
        set => _radiusB = value;
    }

    public MainWindowViewModel()
    {
        _points = new HashSet<Point>();
        _type = ShapeType.Shape;
    }
    
    public string? PointerMsg (PointerPoint point)
    {
        var x = point.Position.X;
        var y = point.Position.Y;

        switch (Type)
        { 
            case ShapeType.Point or ShapeType.Ellipse:
                _points.Clear();
                _points.Add(new Point(x: x, y: y));
                break;
            case ShapeType.Line:
                if (_points.Count == 2) _points.Clear();
                _points.Add(new Point(x: x, y: y));
                break;
            case ShapeType.Polygon: 
                _points.Add(new Point(x: x, y: y));
                break;
            case ShapeType.Shape:
                return "Выберите фигуру!";
        }
        
        
        string result = "Точки: \n[\n";
        foreach (var p in _points)
        {
            result += p + ";\n";
        }
        result += "]\n";
                
        return result;
    }

    public void ClearPoints()
    {
        _points.Clear();
    }

    public string? Characteristics()
    {
        if (_points.Count == 0) return "Недостаточное кол-во точек.";
        return Convert.ToString(Type switch
        {
            ShapeType.Point => _points.First().BaseInformation(),
            ShapeType.Line => new Line(_points.First(), _points.Last()).BaseInformation(),
            ShapeType.Ellipse => new Ellipse(_points.First(), RadiusA, RadiusB).BaseInformation(),
            ShapeType.Polygon => new Polygon(_points.ToList()).BaseInformation(),
            _ => "Невозможно получить информацию о фигуре."
        });
        
    }
}