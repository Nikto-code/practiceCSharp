using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace task1
{
    public class ChatService
    {
        private const string PipeName = "FinanceChatPipe";

        public async Task StartServerAsync(Action<string> onMessageReceived)
        {
            while (true)
            {
                try
                {
                    using var server = new NamedPipeServerStream(
                        PipeName, PipeDirection.In, 1,
                        PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                    await server.WaitForConnectionAsync();
                    byte[] buffer = new byte[512];
                    int bytesRead = await server.ReadAsync(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    onMessageReceived?.Invoke(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка сервера: " + ex.Message);
                }
            }
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                using var client = new NamedPipeClientStream(
                    ".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);
                await client.ConnectAsync(2000);
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await client.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка отправки: " + ex.Message);
            }
        }
    }

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
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    ChatMessages.Add("Другой пользователь: " + msg));
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}