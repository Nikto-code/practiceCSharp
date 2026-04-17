using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите A: ");
        int A = int.Parse(ReadLine());
        Write("Введите B: ");
        int B = int.Parse(ReadLine());
        int count = 0;
        for (int i = B - 1; i > A; i--)
        {
            Write(i + " ");
            count++;
        }
        WriteLine($"\nКоличество: {count}");
    }
}