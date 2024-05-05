using System;
using System.Collections.Generic;

namespace Lab_2.Models;

public class Polygon(List<Point> vertices) : Shape(vertices[0].X, vertices[0].Y)
{
    protected List<Point> _vertices = vertices; // Список вершин полигона
    
    public new (double x, double y) Center
    {
        get
        {
            double accumulatedArea = 0.0d;
            double centerX = 0.0d;
            double centerY = 0.0d;

            for (int i = 0, j = _vertices.Count - 1; i < _vertices.Count; j = i++)
            {
                double temp = _vertices[i].X * _vertices[j].Y - _vertices[j].X * _vertices[i].Y;
                accumulatedArea += temp;
                centerX += (_vertices[i].X + _vertices[j].X) * temp;
                centerY += (_vertices[i].Y + _vertices[j].Y) * temp;
            }

            if (Math.Abs(accumulatedArea) < 1E-7d) return (0.0d, 0.0d);
            
            accumulatedArea *= 3d;
            return (centerX / accumulatedArea, centerY / accumulatedArea);

        }
    }

    public override string BaseInformation()
    {
        if (_vertices.Count < 3) return "Мало точек для прощёта информации о фигуре!";
        return " Многоугольник\n Центр: " + Center + "\n Площадь: " + Area();
    }

    public override double Area()
    {
        double area = 0;
        for (int i = 0; i < _vertices.Count; i++)
        {
            int j = (i + 1) % _vertices.Count;
            area += _vertices[i].X * _vertices[j].Y - _vertices[j].X * _vertices[i].Y;
        }

        return Math.Abs(area / 2);
    }
}