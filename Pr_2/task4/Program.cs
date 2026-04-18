using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите N: ");
        int n = int.Parse(ReadLine());

        int[,] a = new int[n, n];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                a[i, j] = rnd.Next(1, 10);

        WriteLine("Матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Write(a[i, j] + " ");
            WriteLine();
        }

        Write("Введите номер строки: ");
        int k = int.Parse(ReadLine());

        int sum = 0;
        for (int j = 0; j < n; j++)
            sum += a[k, j];

        WriteLine($"Сумма = {sum}");

        if (sum % 10 == 0)
            WriteLine("Да, оканчивается на 0");
        else
            WriteLine("Нет");
    }
}