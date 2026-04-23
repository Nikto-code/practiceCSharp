using static System.Console;
class Program
{
    static void Main()
    {
        int K = int.Parse(ReadLine());
        int D1 = int.Parse(ReadLine());
        int D2 = int.Parse(ReadLine());
        Utils.AddLeftDigit(D1, ref K);
        WriteLine(K);
        Utils.AddLeftDigit(D2, ref K);
        WriteLine(K);
    }
}