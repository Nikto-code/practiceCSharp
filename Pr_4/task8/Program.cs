using static System.Console;

class Program
{
    static void Main()
    {
        int n = 5;
        MathUtils.CalculateFactorial(in n, out long fact);
        WriteLine(fact);

        double d = 3.0;
        MathUtils.CalculateFactorial(in d, out double fact2);
        WriteLine(fact2);
    }
}