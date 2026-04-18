using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Введите N (<10): ");
        int N = int.Parse(ReadLine());

        Write("Введите a: ");
        int a = int.Parse(ReadLine());

        Write("Введите b: ");
        int b = int.Parse(ReadLine());

        int[,] m = new int[N, N];
        Random rnd = new Random();

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                m[i, j] = rnd.Next(a, b + 1);

        WriteLine("Матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Write(m[i, j] + "\t");
            WriteLine();
        }

        Write("Введите E: ");
        int E = int.Parse(ReadLine());

        Write("Введите F: ");
        int F = int.Parse(ReadLine());

        int sumSquares = 0;

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                if (m[i, j] > E && m[i, j] <= F)
                    sumSquares += m[i, j] * m[i, j];

        WriteLine($"Сумма квадратов = {sumSquares}");

        Write("Введите номер столбца k (0..N-1): ");
        int k = int.Parse(ReadLine());

        int sumCol = 0;

        for (int i = 0; i < N; i++) sumCol += m[i, k];
        WriteLine($"Сумма столбца = {sumCol}");
    }
}