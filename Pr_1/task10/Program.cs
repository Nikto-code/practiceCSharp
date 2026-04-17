using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите n: ");
        int n = int.Parse(ReadLine());
        double maxAbs = 0;
        for (int i = 1; i <= n; i++)
        {
            Write($"a[{i}] = ");
            double a = double.Parse(ReadLine());
            if (Math.Abs(a) > maxAbs)
            {
                maxAbs = Math.Abs(a);
            }
        }
        WriteLine($"Максимальный по модулю элемент: {maxAbs}");
    }
}