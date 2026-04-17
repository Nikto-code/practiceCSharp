using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите m: ");
        double m = double.Parse(ReadLine());

        double z1 = Math.Sqrt(Math.Pow(3 * m + 2, 2) - 24 * m) /
                    (3 * Math.Sqrt(m) - 2 / Math.Sqrt(m));

        double z2 = -Math.Sqrt(m);

        WriteLine($"z1 = {z1:F5}");
        WriteLine($"z2 = {z2:F5}");
    }
}