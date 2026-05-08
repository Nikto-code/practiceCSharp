using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace task1
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserManager _userManager = new UserManager();

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(nameof(StatusMessage)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
            RegisterCommand = new RelayCommand(_ => Register());
        }

        private void Login()
        {
            var user = _userManager.Authenticate(Username, Password);
            if (user != null)
            {
                StatusMessage = $"Вход выполнен! Роль: {user.Role}";

                var main = new MainWindow(user);
                main.Show();

                foreach (Window w in Application.Current.Windows)
                {
                    if (w is LoginWindow)
                    {
                        w.Close();
                        break;
                    }
                }
            }
            else
            {
                StatusMessage = "Ошибка авторизации!";
            }
        }

        private void Register()
        {
            bool result = _userManager.RegisterUser(Username, Password, UserRole.User);
            StatusMessage = result ? "Регистрация успешна!" : "Пользователь уже существует!";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}