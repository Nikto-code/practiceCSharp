using static System.Console;

class Program
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.AddLog("Запуск программы");
        logger.AddLog("Ошибка соединения");
        logger.AddLog("Повторное подключение");
        WriteLine("Последний лог:");
        var last = logger.GetLast();
        WriteLine(last.Message);
        WriteLine("\nПоиск 'Ошибка':");
        var found = logger.Find("Ошибка");
        if (found != null) WriteLine(found.Message);
        WriteLine("\nВсе логи с 'подключение':");
        var filtered = logger.Filter("подключение");
        foreach (var log in filtered) WriteLine(log.Message);
        WriteLine("\nСортировка:");
        var sorted = logger.GetSorted();
        foreach (var log in sorted) WriteLine($"{log.Timestamp} - {log.Message}");
    }
}