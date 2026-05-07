using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace task1
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ChatService _chatService = new ChatService();

        private string _messageText = string.Empty;
        public string MessageText
        {
            get => _messageText;
            set { _messageText = value; OnPropertyChanged(nameof(MessageText)); }
        }

        public ObservableCollection<string> ChatMessages { get; set; } = new ObservableCollection<string>();

        public ICommand SendMessageCommand { get; }

        public ChatViewModel()
        {
            SendMessageCommand = new AsyncRelayCommand(async () =>
            {
                if (string.IsNullOrWhiteSpace(MessageText)) return;
                await _chatService.SendMessageAsync(MessageText);
                ChatMessages.Add("Вы: " + MessageText);
                MessageText = string.Empty;
            });

            _ = _chatService.StartServerAsync(msg =>
            {
                App.Current.Dispatcher.Invoke(() =>
                    ChatMessages.Add("Другой пользователь: " + msg));
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}