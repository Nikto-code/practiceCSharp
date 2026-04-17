using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите сторону a: ");
        double a = double.Parse(ReadLine());

        Write("Введите сторону b: ");
        double b = double.Parse(ReadLine());

        Write("Введите сторону c: ");
        double c = double.Parse(ReadLine());

        double p = (a + b + c) / 2;

        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        WriteLine($"Площадь треугольника: {S:F3}");
    }
}