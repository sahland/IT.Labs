namespace lab2_5.Models
{
    public sealed class Line : BaseFigure
    {
        private Point _start;
        private Point _stop;

        public Line(Point start, Point stop) : base((start._x + stop._x) / 2, (start._y + stop._y) / 2)
        {
            _start = start;
            _stop = stop;
        }

        public override double GetArea()
        {
            return 0;
        }
    }
}
