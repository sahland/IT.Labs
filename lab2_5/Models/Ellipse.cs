using System;

namespace Lab_2.Models;

public class Ellipse(Point center, double radius1, double radius2)
    : Shape(center.X, center.Y)
{

    public override double Area() => Math.PI * radius1 * radius2;
    
    public override string BaseInformation()
    {
        return " Эллипс\n Радиус A: " + radius1 + "\n Радиус B: " + radius2 + "\n Центр: " + Center + "\n Площадь: " + Area();
    }
}