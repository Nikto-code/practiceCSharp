using System;
using System.Collections.Generic;
using System.Text;

interface ITaskManager<T> {
    void AddTask(T task);
    void CompleteTask(T task);
}