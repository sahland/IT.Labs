using lab1_3.ViewModel;
using System.Windows;


namespace lab1_3
{
    public partial class MainWindow : Window
    {
        public StackVM<string> ViewModel { get; } = new StackVM<string>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}