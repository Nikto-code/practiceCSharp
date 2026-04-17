using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("a= ");
        int a = int.Parse(ReadLine());

        Write("b= ");
        int b = int.Parse(ReadLine());

        Write("c= ");
        int c = int.Parse(ReadLine());

        WriteLine($"{a} * {b} * {c} = {c} * {b} * {a}");
    }
}