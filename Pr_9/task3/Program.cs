using static System.Console;
class Program {
    static void Main() {
        SensorFileReader reader = new SensorFileReader();
        List<SensorData> data = reader.ReadSensorData();
        SensorProcessor processor = new SensorProcessor();
        double avg = processor.CalculateAverageValue(data);
        WriteLine($"Среднее значение: {avg}");
    }
}