using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите строку: ");
        string s = ReadLine();
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string result = "";

        foreach (string w in words)
        {
            if (!result.Contains(w + " "))
            {
                result += w + " ";
            }
        }
        WriteLine("Результат: " + result.Trim());
    }
}