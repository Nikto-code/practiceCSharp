using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        double x = 2.7;

        double y = 3 * Math.Pow(x, 2) + Math.Exp(Math.Sqrt(x)) / (2 * Math.PI) - Math.Log(Math.Sqrt(Math.Abs(3 - Math.Pow(Math.Sin(x), 2))));
        WriteLine("При x = {0}, значение функции y = {1:F6}", x, y);
    }
}
