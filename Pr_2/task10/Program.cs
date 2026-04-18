using System;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите строку: ");
        string s = ReadLine();

        if (Regex.IsMatch(s, @"^[A-ZА-Я]"))
            WriteLine("Строка начинается с заглавной буквы");
        else
            WriteLine("Нет");
    }
}