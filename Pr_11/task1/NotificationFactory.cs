using System;
using System.Collections.Generic;
using System.Text;

abstract class NotificationFactory
{
    public abstract INotification CreateNotification();
}