using System.Collections.Generic;

class SensorProcessor {
    public double CalculateAverageValue(List<SensorData> data) {
        if (data.Count == 0) return 0;
        double sum = 0;
        for (int i = 0; i < data.Count; i++) { sum += data[i].Value; }
        return sum / data.Count;
    }
}