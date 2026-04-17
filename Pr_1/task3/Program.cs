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
        int sum = 0;
        for (int i = A; i <= B; i++)
        {
            sum += i * i;
        }
        WriteLine($"Сумма квадратов = {sum}");
    }
}