using System;
using System.Collections.Generic;
using System.Text;

class EmailNotification : INotification
{
    public string Send(string message)
    {
        return $"Email: {message}";
    }
}
class SMSNotification : INotification
{
    public string Send(string message)
    {
        return $"SMS: {message}";
    }
}
class PushNotification : INotification
{
    public string Send(string message)
    {
        return $"Push: {message}";
    }
}