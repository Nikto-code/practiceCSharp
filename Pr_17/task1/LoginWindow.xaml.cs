using System.Windows;

namespace task1
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _vm = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
    
        private void OnPasswordCapture(object sender, RoutedEventArgs e)
        {
            _vm.Password = PasswordBox.Password;
        }
    }
}