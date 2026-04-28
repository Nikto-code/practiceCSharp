using static System.Console;

class Program
{
    static void Main()
    {
        FileWatcher watcher = new FileWatcher("data");
        watcher.Start();
        WriteLine("Отслеживание запущено");
        ReadLine();
    }
}