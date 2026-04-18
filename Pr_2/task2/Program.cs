using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double[] a = new double[25];
        Random rnd = new Random();
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = rnd.Next(-10, 10);
            Write(a[i] + " ");
        }
        WriteLine();
        double min = a[0], max = a[0];
        foreach (double x in a)
        {
            if (x < min) min = x;
            if (x > max) max = x;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] >= 0) a[i] *= min * min;
            else
                a[i] *= max * max;
        }
        foreach (double x in a)
            Write(x + " ");
        Array.Sort(a);
        foreach (double x in a)
            Write(x + " ");
        Write("\nВведите k: ");
        double k = double.Parse(ReadLine());
        int index = Array.BinarySearch(a, k);
        if (index >= 0) WriteLine($"Найден, индекс = {index}");
        else
            WriteLine("Не найден");
    }
}