using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите x: ");
        double x = double.Parse(ReadLine());
        double y = 3 * Math.Pow(x, 2) + Math.Exp(Math.Sqrt(x)) / (2 * Math.PI) - Math.Log(Math.Sqrt(Math.Abs(3 - Math.Pow(Math.Sin(x), 2))));
        WriteLine($"y = {y:F5}");
    }
}
