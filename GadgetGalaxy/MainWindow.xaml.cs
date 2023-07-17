using GadgetGalaxy.VMs;
using GadgetGalaxyDatabase;
using System.Windows;
using System.Windows.Controls;

namespace GadgetGalaxy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindowVM _MainWindowVM = new MainWindowVM(new GGDbContext());

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _MainWindowVM;
        }

        private void PasswordChange(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _MainWindowVM.Password = passwordBox.Password;
            }
        }

    }
}
