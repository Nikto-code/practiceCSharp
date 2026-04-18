using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int[][] a = new int[3][];
        Random rnd = new Random();

        for (int i = 0; i < a.Length; i++)
        {
            a[i] = new int[rnd.Next(3, 7)];

            for (int j = 0; j < a[i].Length; j++)
                a[i][j] = rnd.Next(1, 10);
        }

        WriteLine("Массив:");
        for (int i = 0; i < a.Length; i++)
        {
            foreach (int x in a[i])
                Write(x + " ");
            WriteLine();
        }

        int maxUnique = 0;
        int index = 0;

        for (int i = 0; i < a.Length; i++)
        {
            int unique = 0;

            for (int j = 0; j < a[i].Length; j++)
            {
                bool isUnique = true;

                for (int k = 0; k < a[i].Length; k++)
                {
                    if (j != k && a[i][j] == a[i][k])
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique) unique++;
            }

            if (unique > maxUnique)
            {
                maxUnique = unique;
                index = i;
            }
        }

        WriteLine($"Строка с макс. уникальными элементами: {index}");
    }
}