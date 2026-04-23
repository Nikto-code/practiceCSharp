using static System.Console;
class Program
{
    static void Main()
    {
        WriteLine(StringUtils.GetLength("Hello")); 
        string[] arr = { "Hi", "Hello" };
        WriteLine(StringUtils.GetLength(arr)); 
    }
}