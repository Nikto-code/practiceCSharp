using System;
using System.Collections.Generic;
using System.Text;

public delegate string ServerEventHandler(string message);
class ServerShutdownManager
{
    public event ServerEventHandler ServerShuttingDown;

    public string[] Shutdown()
    {
        var delegates = ServerShuttingDown.GetInvocationList();
        string[] results = new string[delegates.Length];
        for (int i = 0; i < delegates.Length; i++)
        {
            var handler = (ServerEventHandler)delegates[i];
            results[i] = handler("Сервер выключается");
        }

        return results;
    }
}