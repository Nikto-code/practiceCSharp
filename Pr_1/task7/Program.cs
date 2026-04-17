using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int A = 10, B = 50, X = 3;
        for (int i = A; i <= B; i++)
        {
            if (i % 10 == X)
                Write(i + " ");
        }
        int i = A;
        while (i <= B)
        {
            if (i % 10 == X)
                Write(i + " ");
            i++;
        }
        do
        {
            if (i % 10 == X)
                Write(i + " ");
            i++;
        }
        while (i <= B);
    }
}