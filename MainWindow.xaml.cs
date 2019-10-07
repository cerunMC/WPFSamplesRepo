using System.Windows;

namespace Selectize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowVM mainWindowVM = new MainWindowVM();
            DataContext = mainWindowVM;
        }
    }
}
