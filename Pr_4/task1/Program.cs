using static System.Console;
class Program
{
    static void Main()
    {
        int num = int.Parse(ReadLine());
        if (MathUtils.IsPrime(num)) WriteLine("Простое");
        else
            WriteLine("Не простое");
    }
}