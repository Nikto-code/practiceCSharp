using static System.Console;

class Program
{
    static void Main()
    {
        ServerShutdownManager manager = new ServerShutdownManager();

        BackupService backup = new BackupService();
        AlertSystem alert = new AlertSystem();

        manager.ServerShuttingDown += backup.CreateBackup;
        manager.ServerShuttingDown += alert.SendAlert;

        string[] results = manager.Shutdown();

        foreach (var r in results)
            WriteLine(r);
    }
}