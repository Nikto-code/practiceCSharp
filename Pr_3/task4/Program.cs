using static System.Console;

class Program
{
    static void Main()
    {
        BankClient[] clients =
        {
            new BankClient("Иван", 1000),
            new BankClient("Анна", 500),
            new BankClient("Петр", 2000),
            new BankClient("Мария", 300)
        };
        Bank bank = new Bank(clients);
        WriteLine("Клиенты с низким балансом:");
        var low = bank.GetClientsWithLowBalance(800);
        for (int i = 0; i < low.Length; i++)
        {
            WriteLine(low[i].Name + " - " + low[i].AccountBalance);
        }
        var richest = bank.GetRichestClient();
        WriteLine("\nСамый богатый: " + richest.Name + " - " + richest.AccountBalance);
    }
}