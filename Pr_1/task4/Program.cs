using System;
using static System.Console;
class Program
{
    static void Main()
    {
        Write("Введите x: ");
        double x = double.Parse(ReadLine());
        double y;
        if (x > 2.8 && x < 6)
        {
            y = (x - 1) / (x + 1);
        }
        else if (x > 6)
        {
            y = Math.Exp(x) + Math.Sin(x);
        }
        else
        {
            WriteLine("x не входит в заданные интервалы");
            return;
        }
        WriteLine($"y = {y:F4}");
    }
}