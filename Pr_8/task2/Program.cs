using static System.Console;
class Program
{
    static void Main()
    {
        PriorityTaskManager<string> manager = new PriorityTaskManager<string>();
        manager.AddTask("Рассказать анекдот", 2);
        manager.AddTask("Поспать", 1);
        manager.AddTask("Сдать проект от chatGPT", 5);
        WriteLine($"Следующая задача:\n{manager.ViewNextTask()}");
        WriteLine($"\nВыполняем:\n{manager.ExecuteTask()}");
        WriteLine($"\nСледующая:\n{manager.ViewNextTask()}");
    }
}