using System;

namespace lab2_5.Models
{
    public sealed class Ellipse : BaseFigure
    {
        private Point[] _points;
        private double _majorRadius;
        private double _minorRadius;

        public Ellipse(int pointCount) : base(0, 0)
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

            _majorRadius = GetMajorRadius();
            _minorRadius = GetMinorRadius();
        }

        private double GetMajorRadius()
        {
            double maxRadius = 0;
            for (int i = 0; i < _points.Length; i++)
            {
                double radius = Math.Sqrt(Math.Pow(_points[i]._x - _x, 2) + Math.Pow(_points[i]._y - _y, 2));
                if (radius > maxRadius)
                {
                    maxRadius = radius;
                }
            }

            return maxRadius;
        }

        private double GetMinorRadius()
        {
            double minRadius = double.MaxValue;
            for (int i = 0; i < _points.Length; i++)
            {
                double radius = Math.Sqrt(Math.Pow(_points[i]._x - _x, 2) + Math.Pow(_points[i]._y - _y, 2));
                if (radius < minRadius)
                {
                    minRadius = radius;
                }
            }

            return minRadius;
        }

        public override double GetArea()
        {
            return Math.PI * _majorRadius * _minorRadius;
        }

    }
}
