using System;
using static System.Console;
class Program
{
    static void Main()
    {
        Write("Введите a: ");
        int a = int.Parse(ReadLine());
        Write("Введите b: ");
        int b = int.Parse(ReadLine());
        A obj = new A(a, b);
        WriteLine("\nb^3 - 4*sqrt(a) = " + obj.CalcExpression());
        WriteLine("(a / b)^2 = " + obj.SquareQuotient());
    }
}