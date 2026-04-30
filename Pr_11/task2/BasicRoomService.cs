using System;
using System.Collections.Generic;
using System.Text;

class BasicRoomService : IRoomService
{
    public string GetServiceDetails()
    {
        return "Базовый сервис (уборка)";
    }

    public double GetCost()
    {
        return 100;
    }
}