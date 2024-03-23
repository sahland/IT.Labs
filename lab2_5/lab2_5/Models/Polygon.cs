namespace lab2_5.Models
{
    public sealed class Polygon : BaseFigure
    {
        private Point[] _points;

        public Polygon(int pointCount) : base(0, 0)
        {
            _points = new Point[pointCount];
        }

        public void SetPoint(int index, double x, double y)
        {
            _points[index] = new Point(x, y);

            double sumX = 0;
            double sumY = 0;
            for (int i = 0; i < _points.Length; i++)
            {
                sumX += _points[i]._x;
                sumY += _points[i]._y;
            }

            _x = sumX / _points.Length;
            _y = sumY / _points.Length;
        }

        public override double GetArea()
        {
            double area = 0;
            for (int i = 0; i < _points.Length; i++)
            {
                int j = (i + 1) % _points.Length;
                area += _points[i]._x * _points[j]._y - _points[j]._x * _points[i]._y;
            }

            return area / 2;
        }
    }
}
