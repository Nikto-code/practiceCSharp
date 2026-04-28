using System;
using System.Collections.Generic;
using System.Text;

class SensorFileReader {
    public string filePath = @"..\..\..\file.data";
    public List<SensorData> ReadSensorData() {
        List<SensorData> result = new List<SensorData>();
        StreamReader reader = new StreamReader(filePath);
        try {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(';');
                DateTime time = DateTime.Parse(parts[0]);
                double value = double.Parse(parts[1]);
                result.Add(new SensorData(time, value));
            }
        }
        finally { reader.Close(); }
        return result;
    }
}