using static System.Console;
static class DoubleExtensions
{
    public static double RoundTo(this double value, int digits)
    {
        return Math.Round(value, digits);
    }
}

class Program
{
    static void Main()
    {
        double x = 3.1415926;

        double result = x.RoundTo(3);

        WriteLine(result);
    }
}