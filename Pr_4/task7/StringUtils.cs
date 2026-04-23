using System;
using System.Collections.Generic;
using System.Text;

class StringUtils
{
    public static int GetLength(string str)
    {
        return str.Length;
    }
    public static int GetLength(string[] arr)
    {
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
            sum += arr[i].Length;

        return sum;
    }
}
