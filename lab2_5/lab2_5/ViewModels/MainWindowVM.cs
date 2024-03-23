using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_5.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        public DelegateCommand PointCommand { get; private set; }
        public DelegateCommand LineCommand { get; private set; }
        public DelegateCommand PolygonCommand { get; private set; }
        public DelegateCommand EllipseCommand { get; private set; }

        public MainWindowVM()
        {
            PointCommand = new DelegateCommand(CreatePoint);
            LineCommand = new DelegateCommand(CreateLine);
            PolygonCommand = new DelegateCommand(CreatePolygon);
            EllipseCommand = new DelegateCommand(CreateEllipse);
        }

        private void CreatePoint()
        {

        }

        private void CreateLine()
        {

        }

        private void CreatePolygon()
        {

        }

        private void CreateEllipse()
        {

        }
    }
}
