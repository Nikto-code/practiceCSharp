using System;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace task1
{
    public class NotificationService
    {
        private const string MmfName = "FinanceNotifications";
        private const int MmfSize = 1024;

        public void SendNotification(string message)
        {
            try
            {
                using var mmf = MemoryMappedFile.CreateOrOpen(MmfName, MmfSize);
                using var accessor = mmf.CreateViewAccessor();
                byte[] data = Encoding.UTF8.GetBytes(message);
                accessor.WriteArray(0, data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка отправки уведомления: " + ex.Message);
            }
        }

        public string ReadNotification()
        {
            try
            {
                using var mmf = MemoryMappedFile.OpenExisting(MmfName);
                using var accessor = mmf.CreateViewAccessor();
                byte[] buffer = new byte[MmfSize];
                accessor.ReadArray(0, buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}