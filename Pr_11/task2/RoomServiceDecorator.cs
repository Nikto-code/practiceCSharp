using System;
using System.Collections.Generic;
using System.Text;
abstract class RoomServiceDecorator : IRoomService
{
    protected IRoomService _service;

    public RoomServiceDecorator(IRoomService service)
    {
        _service = service;
    }

    public virtual string GetServiceDetails()
    {
        return _service.GetServiceDetails();
    }

    public virtual double GetCost()
    {
        return _service.GetCost();
    }
}