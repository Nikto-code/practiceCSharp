using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите строку: ");
        StringBuilder sb = new StringBuilder(ReadLine());
        Write("Введите подстроку: ");
        string sub = ReadLine();

        if (sb.ToString().EndsWith(sub))
            WriteLine("Да, заканчивается");
        else
            WriteLine("Нет");
    }
}