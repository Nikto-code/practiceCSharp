using System;
using System.Collections.Generic;
using System.Text;
class Utils
{
    public static void AddLeftDigit(int D, ref int K)
    {
        int temp = K;
        int power = 1;
        while (temp > 0)
        {
            power *= 10;
            temp /= 10;
        }
        K = D * power + K;
    }
}
