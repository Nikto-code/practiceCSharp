using System.Collections.Generic;

class TaskManager<T> : ITaskManager<T> {
    private TaskStorage<T> storage = new TaskStorage<T>();
    public void AddTask(T task) { storage.Add(task); }
    public void CompleteTask(T task) { storage.Remove(task); }
    public List<T> GetTasks() { return storage.GetAll(); }
}