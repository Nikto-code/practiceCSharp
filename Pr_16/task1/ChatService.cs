using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

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
}