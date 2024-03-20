using lab1_3.ViewModel;
using System.Windows;

namespace lab1_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new StackVM();
        }
    }
}