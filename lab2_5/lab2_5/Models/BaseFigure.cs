using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace lab2_5.Models
{
    public abstract class BaseFigure
    {
        public Double _x;
        public Double _y;

        public BaseFigure(Double x, Double y)
        {
            _x = x;
            _y = y;
        }

        public abstract Double GetArea();
    }
}
