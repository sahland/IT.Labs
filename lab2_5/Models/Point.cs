using System;

namespace Lab_2.Models;

public class Point(double x, double y) : Shape(x, y)
{
    public double X
    {
        get => _x;
    }
    public double Y
    {
        get => _y;
    }

    public override double Area() => 0;
    

    public override string BaseInformation()
    {
        return "Точка\n Центр: " + Center + "\n Площадь: " + Area();
    }

    public override int GetHashCode()
    {
        int prime = 31;
        return prime + prime * (int) x + prime + prime * (int) y;
    }

    public override bool Equals(object? obj)
    {
        var item = obj as Point;
        
        if (item == null) return false;
        
        return X.Equals(item.X) && Y.Equals(item.Y);
    }

    public override string ToString()
    {
        return String.Format($"({X}, {Y})");
    }
}