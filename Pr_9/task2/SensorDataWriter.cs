using System;
using System.Collections.Generic;
using System.Text;

class SensorDataWriter {
    private string filePath = "file.data";
    public void ClearAndWrite(List<SensorData> data) {
        StreamWriter writer = new StreamWriter(filePath, false);
        try {
            foreach (var item in data) {
                string line = $"{item.Timestamp:yyyy-MM-dd HH:mm:ss};{item.Value}";
                writer.WriteLine(line);
            }
        }
        finally { writer.Close(); }
    }
}