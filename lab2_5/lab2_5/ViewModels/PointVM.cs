using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab2_5.ViewModels
{
    public sealed class PointVM : BaseFigureVM
    {
        private double _x;
        private double _y;

        public PointVM(double x, double y) : base("Point")
        {
            X = x;
            Y = y;
        }

        public override void Draw(Canvas canvas)
        {

            var ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = Brushes.Black,
                Stroke = Brushes.Black,
                Canvas.LeftProperty = X - 2.5,
                Canvas.TopProperty = Y - 2.5
            };

            canvas.Children.Add(ellipse);
        }

    }
}
