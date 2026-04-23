using System;
using System.Collections.Generic;
using System.Text;

class MathUtils
{
    public static void CalculateFactorial(in int number, out long result)
    {
        result = 1;

        for (int i = 1; i <= number; i++)
            result *= i;
    }
    public static void CalculateFactorial(in double number, out double result)
    {
        int n = (int)Math.Round(number);
        result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;
    }
}
