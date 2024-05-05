namespace Lab_2.Models;

public class Line(Point pointStart, Point pointEnd)
    : Shape((pointStart.X + pointEnd.X) / 2.0, (pointStart.Y + pointEnd.Y) / 2.0)
{

    public new (double x, double y) Center => ((PointStart.X + PointEnd.X) / 2.0, (PointStart.Y + PointEnd.Y) / 2.0);

    public Point PointStart
    {
        get;
    } = pointStart;

    public Point PointEnd
    {
        get;
    } = pointEnd;
    
    public override double Area() => 0;
    
    public override string BaseInformation()
    {
        return " Линия\n Центр: " + Center + "\n Площадь: " + Area();
    }
}