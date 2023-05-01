using System.Windows;
using System.Windows.Controls;
using Ibf.Wpf.AutoConnector.ViewModel;

namespace Ibf.Wpf.AutoConnector.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            DataContext = ViewModel = viewModel;
            InitializeComponent();

            PasswordBox.Password = viewModel.Password;
        }

        public MainViewModel ViewModel { get; }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = (sender as PasswordBox)?.Password ?? string.Empty;
        }
    }
}