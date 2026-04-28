using static System.Console;
using System.Collections.Generic;

class Program {
    static void Main() {
        var data = new List<SensorData>() {
            new SensorData(DateTime.Now, 23.5),
            new SensorData(DateTime.Now.AddMinutes(1), 24.1),
            new SensorData(DateTime.Now.AddMinutes(2), 22.8)
        };
        SensorDataWriter writer = new SensorDataWriter();
        writer.ClearAndWrite(data);
        WriteLine("Данные записаны.");
    }
}