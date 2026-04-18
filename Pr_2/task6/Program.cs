using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите строку: ");
        string s = ReadLine();
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int count = 0;

        foreach (string word in words)
        {
            bool isLatin = true;

            foreach (char c in word)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    isLatin = false;
                    break;
                }
            }
            if (isLatin)
                count++;
        }
        WriteLine($"Количество слов из латиницы: {count}");
    }
}