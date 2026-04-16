using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите трехзначное число: ");
        int number = int.Parse(ReadLine());

        int first = number / 100;
        int second = (number / 10) % 10;
        int third = number % 10;

        int result = first * 100 + third * 10 + second;

        WriteLine($"Результат: {result}");
    }
}