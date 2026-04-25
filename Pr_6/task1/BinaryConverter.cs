using System;
using System.Collections.Generic;
using System.Text;

public delegate string NumberConverter(int number);
class BinaryConverter {
    public string Convert(int number) {
        return ConvertToBase(number, 2);
    }
    private string ConvertToBase(int number, int baseNum) {
        string result = "";
        int n = number;
        while (n > 0) {
            result = (n % baseNum) + result;
            n /= baseNum;
        }
        return result;
    }
}
