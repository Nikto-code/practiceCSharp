using System;
using static System.Console;
class Program
{
    static void Main()
    {
        int n = int.Parse(ReadLine());
        double[] a = new double[n];
        for (int i = 0; i < n; i++)
        {
            Write($"a[{i}] = ");
            a[i] = double.Parse(ReadLine());
        }
        double product = 1;
        for (int i = 0; i < n; i += 2)
        {
            product *= a[i];
        }
        WriteLine($"Произведение = {product}");
    }
}