using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double A = 7;
        double B = 15;
        int M = 2;
        double H = (B - A) / M;
        double x = A;
        for (int i = 0; i <= M; i++)
        {
            double y = Math.Atan(x);
            WriteLine($"x = {x:F2}  y = {y:F4}");
            x += H;
        }
    }
}