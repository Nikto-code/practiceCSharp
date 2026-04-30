using static System.Console;

class Program
{
    static void Main()
    {
        NotificationFactory factory = new EmailFactory();
        INotification notification = factory.CreateNotification();
        WriteLine(notification.Send("Привет"));
        factory = new SMSFactory();
        notification = factory.CreateNotification();
        WriteLine(notification.Send("Привет"));
        factory = new PushFactory();
        notification = factory.CreateNotification();
        WriteLine(notification.Send("Привет"));
    }
}