using System;
using System.Collections.Generic;
using System.Text;

class AirportPickupDecorator : RoomServiceDecorator
{
    public AirportPickupDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails()
    {
        return _service.GetServiceDetails() + " + Трансфер";
    }

    public override double GetCost()
    {
        return _service.GetCost() + 30;
    }
}