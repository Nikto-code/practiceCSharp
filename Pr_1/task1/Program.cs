using System;
using static System.Console;
class Program
{
    static void Main()
    {
        Write("Введите радиус: ");
        double r = double.Parse(ReadLine());
        WriteLine($"Диаметр = {2 * r}");
    }
}