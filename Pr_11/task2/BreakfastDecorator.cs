using System;
using System.Collections.Generic;
using System.Text;

class BreakfastDecorator : RoomServiceDecorator
{
    public BreakfastDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails()
    {
        return _service.GetServiceDetails() + " + Завтрак";
    }

    public override double GetCost()
    {
        return _service.GetCost() + 20;
    }
}