using System;
using System.Windows.Shapes;

namespace lab2_5.Models
{
    public sealed class Point : BaseFigure
    {
        private Double _x;
        private Double _y;

        public Point(Double x, Double y) : base(x, y) {
            _x = x;
            _y = y;
        }

        public override Double GetArea() { return 0; }
    }
}
