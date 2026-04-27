using static System.Console;
using System.Collections.Generic;

class Program {
    static void Main() {
        TaskManager<string> manager = new TaskManager<string>();
        manager.AddTask("Рассказать анекдот");
        manager.AddTask("Поспать");
        manager.AddTask("Сдать проект от chatGPT");
        WriteLine("Все задачи:");
        Print(manager.GetTasks());
        manager.CompleteTask("Поспать");
        WriteLine("\nПосле выполнения:");
        Print(manager.GetTasks());
    }
    static void Print(List<string> tasks) {
        for (int i = 0; i < tasks.Count; i++) WriteLine(tasks[i]);
    }
}