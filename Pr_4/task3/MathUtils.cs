using System;
using System.Collections.Generic;
using System.Text;
class MathUtils
{
    public static double Power(double baseNum, int exponent)
    {
        if (exponent < 0)
            return 1 / Power(baseNum, -exponent);
        if (exponent == 0)
            return 1;
        if (exponent == 1)
            return baseNum;
        return baseNum * Power(baseNum, exponent - 1);
    }
}