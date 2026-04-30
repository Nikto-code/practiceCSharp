using static System.Console;

class Program
{
    static void Main()
    {
        IRoomService service = new BasicRoomService();

        service = new BreakfastDecorator(service);
        service = new SpaDecorator(service);
        service = new AirportPickupDecorator(service);

        WriteLine(service.GetServiceDetails());
        WriteLine(service.GetCost());
    }
}