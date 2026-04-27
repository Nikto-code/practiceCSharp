using System;
using System.Collections.Generic;
using System.Text;

class PriorityTaskManager<T> {
    private MyPriorityQueue<T> queue = new MyPriorityQueue<T>();
    public void AddTask(T task, int priority) { queue.Enqueue(task, priority); }
    public T ExecuteTask() { return queue.Dequeue(); }
    public T ViewNextTask(){ return queue.Peek(); }
    public int FindTask(T task) { return queue.Find(task); }
}