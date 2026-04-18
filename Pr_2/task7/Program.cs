using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите строку: ");
        string s = ReadLine();
        Write("Что вставить: ");
        string sub = ReadLine();
        Write("Позиция: ");
        int pos = int.Parse(ReadLine());

        if (pos < 0 || pos > s.Length)
        {
            WriteLine("Ошибка позиции");
            return;
        }
        string result = s.Insert(pos, sub);
        WriteLine("Результат: " + result);
    }
}