using static System.Console;
using System;
class Program
{
    static void Main()
    {
        WarehouseMonitor monitor = new WarehouseMonitor();
        InventoryTracker tracker = new InventoryTracker();

        var result = tracker.Track(monitor, "Коробка");

        foreach (var r in result)
            WriteLine(r);
    }
}