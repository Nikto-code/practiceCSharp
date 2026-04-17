using System;
using static System.Console;
class Program
{
    static void Main()
    {
        Write("Масштаб(км в 1 см): ");
        double scale = double.Parse(ReadLine());
        Write("Расстояние на карте (см): ");
        double mapDistance = double.Parse(ReadLine());
        double realDistance = scale * mapDistance;
        WriteLine("Расстояние между пунктами: {0:F2} км", realDistance);
    }
}