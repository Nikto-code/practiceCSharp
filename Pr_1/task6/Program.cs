using System;
using static System.Console;
class Program
{
    static void Main()
    {
        Write("Введите номер месяца: ");
        int m = int.Parse(ReadLine());
        switch (m)
        {
            case 1: WriteLine(11); break;
            case 2: WriteLine(10); break;
            case 3: WriteLine(9); break;
            case 4: WriteLine(8); break;
            case 5: WriteLine(7); break;
            case 6: WriteLine(6); break;
            case 7: WriteLine(5); break;
            case 8: WriteLine(4); break;
            case 9: WriteLine(3); break;
            case 10: WriteLine(2); break;
            case 11: WriteLine(1); break;
            case 12: WriteLine(0); break;
            default: WriteLine("Ошибка"); break;
        }
    }
}