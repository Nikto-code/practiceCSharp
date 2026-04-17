using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите двузначное число: ");
        int n = int.Parse(ReadLine());
        int a = n / 10;
        int b = n % 10;
        int sum = a + b;
        if (sum % 2 == 0)
            WriteLine("Сумма цифр чётная");
        else
            WriteLine("Сумма цифр нечётная");
    }
}