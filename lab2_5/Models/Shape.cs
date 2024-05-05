namespace Lab_2.Models;

public abstract class Shape(double x, double y)
{
    protected double _x = x; // Координата X центра фигуры
    protected double _y = y; // Координата Y центра фигуры

    public (double _x, double _y) Center => (_x, _y);
    public abstract double Area();
    

    public abstract string BaseInformation();
}