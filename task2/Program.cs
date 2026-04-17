using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int number = int.Parse(ReadLine());
        int first = number / 100;
        int last = number % 10;
        WriteLine($"Первая цифра: {first}");
        WriteLine($"Последняя цифра: {last}");
    }
}