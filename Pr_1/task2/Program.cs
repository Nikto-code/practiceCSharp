using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите четырехзначное число: ");
        int n = int.Parse(ReadLine());
        int a = n / 1000;
        int b = (n / 100) % 10;
        int c = (n / 10) % 10;
        int d = n % 10;
        if (a + b == c + d)
            WriteLine("Истина");
        else
            WriteLine("Ложь");
    }
}