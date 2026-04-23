using static System.Console;
class Program
{
    static void Main()
    {
        double a = double.Parse(ReadLine());
        int n = int.Parse(ReadLine());

        try
        {
            double result = MathUtils.Power(a, n);
            WriteLine(result);
        }
        catch (Exception ex)
        {
            WriteLine("Ошибка: " + ex.Message);
        }
    }
}