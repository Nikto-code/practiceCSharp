using System;
using System.Collections.Generic;
using System.Text;

class SpaDecorator : RoomServiceDecorator
{
    public SpaDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails()
    {
        return _service.GetServiceDetails() + " + Спа";
    }

    public override double GetCost()
    {
        return _service.GetCost() + 50;
    }
}