using System;
using System.Collections.Generic;
using System.Text;

class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

class SMSFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

class PushFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}